using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using TimeTable.Common.AppConstants;
using TimeTable.DAL.Repository;
using TimeTable.Model;
using TimeTable.Web.ActionFilter;
using TimeTable.Web.Manager;
using TimeTable.Web.ViewModel;
using System;
using System.Collections.Generic;
using TimeTable.Common;
using TimeTable.Web.Extension;

namespace TimeTable.Web.Controllers {

	public class GroupController : BaseController {
		private IGroupRepository _groupRepository;

		public GroupController(IGroupRepository GroupRepository) {
			_groupRepository = GroupRepository;
		}

		[Style(PageId = Dom.Page.GroupList)]
		public ActionResult Index(GroupFilterVM filterVM) {
			GroupFilter filter = _mapper.Map<GroupFilter>(filterVM);
			var viewModel = _groupRepository.GetGroupItems(filter);
			return View(_mapper.Map<GroupItemsVM>(viewModel));
		}

		[Style(PageId = Dom.Page.GroupDetails)]
		public ActionResult Details(int id) {
			var details = _groupRepository.GetGroupDetails(id);
			if (details == null) {
				return NotFound();
			}
			var viewModel = _mapper.Map<GroupDetailVM>(details);
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details(GroupDetailVM viewModel) {
			if (ModelState.IsValid) {
				var group = _groupRepository.GetEntity<Group>(viewModel.Id);
				group.Name = viewModel.Name;
				group.StudentsCount = viewModel.StudentsCount;
				group.Year = viewModel.Year;
				_groupRepository.UnitOfWork.SaveChanges();
				return RedirectToAction(MVC.Controller.Group.Details, new { id = viewModel.Id });
			}
			return View(viewModel);
		}

		public ActionResult Create() {
			GroupDetailVM viewModel = new GroupDetailVM();
			viewModel.TypeItems =
				_mapper.Map<ICollection<SelectItemVM>>(
					_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.Group)
						.Where(t => t.Id != Dom.DomainValue.Subgroup)
				);
			viewModel.TypeId = Dom.DomainValue.Group;
			return PartialView(MVC.View.Group.Create, viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(GroupDetailVM newGroupVM) {
			if (newGroupVM.SelectedGroups.IsNullOrEmpty()) {
				ModelState.AddModelError("Error", "Stream should contain few groups");
			}
			if (!ModelState.IsValid) {
				return Json(new {
					errors = ModelState.Values.Where(v => v.ValidationState == ModelValidationState.Invalid)
					.Select(e => e.Errors.Select(i => i.ErrorMessage))
				});
			}
			switch (newGroupVM.TypeId) {
				case Dom.DomainValue.Group:
					_groupRepository.Add(
						new Group {
							Name = newGroupVM.Name,
							StudentsCount = newGroupVM.StudentsCount,
							Year = newGroupVM.Year
						}
					);
					break;
				case Dom.DomainValue.Stream:
					var groups = _groupRepository.GetGroups(Dom.DomainValue.Group).Where(g => newGroupVM.SelectedGroups.Contains(g.Id));
					var stream = _groupRepository.Add(
						new Group {
							Name = newGroupVM.Name,
							StudentsCount = (byte?)groups.Sum(g => g.StudentsCount).Value,
						}
					);
					_groupRepository.UnitOfWork.SaveChanges();
					foreach (var groupId in newGroupVM.SelectedGroups) {
						_groupRepository.Add(
							new GroupRelation {
								GroupId = groupId,
								ParentGroupId = stream.Entity.Id
							}
						);
					}
					break;
				case Dom.DomainValue.Subgroup:
					var subGroup = _groupRepository.Add(
						new Group {
							Name = newGroupVM.Name,
							StudentsCount = newGroupVM.StudentsCount,
							Year = newGroupVM.Year
						}
					);
					_groupRepository.UnitOfWork.SaveChanges();
					_groupRepository.Add(
						new GroupRelation {
							GroupId = subGroup.Entity.Id,
							ParentGroupId = newGroupVM.ParentGroupId.Value
						}
					);
					break;

				default:
					break;
			}
			_groupRepository.UnitOfWork.SaveChanges();
			return RedirectToAction(MVC.Controller.Group.List);
		}

		[HttpPost]
		public ActionResult Delete(int id) {
			if (_groupRepository.DeleteById<Group>(id)) {
				_groupRepository.UnitOfWork.SaveChanges();
				return RedirectToAction(MVC.Controller.Group.List);
			}
			return NotFound();
		}

		[HttpGet]
		public JsonResult GetGroupKeyValues(int? typeId = null) {
			return Json(_groupRepository.GetGroups(typeId)
				.Select(s => new KeyValue {
					Id = s.Id,
					Value = s.Name,
				}));
		}

		[HttpGet]
		public JsonResult GetGroupSelectItems(int? typeId = null) {
			return Json(_groupRepository.GetGroups(typeId)
				.Select(s => new SelectItemVM {
					Id = s.Id,
					Value = StyleFormat.FormattedGroupName(s.Name, s.StudentsCount.ToString())
				}));
		}

		private void InitGroupDetailsVM(GroupDetailVM viewModel) {
			viewModel.TypeItems = _mapper.Map<ICollection<SelectItemVM>>(_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.Group));
		}
	}
}