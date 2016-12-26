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

namespace TimeTable.Web.Controllers {

	public class LoadController : BaseController {
		private ILoadRepository _loadRepository;

		public LoadController(ILoadRepository LoadRepository) {
			_loadRepository = LoadRepository;
		}

		[Style(PageId = Dom.Page.LoadList)]
		public ActionResult Index(LoadFilterVM filterVM) {
			LoadFilter filter = _mapper.Map<LoadFilter>(filterVM);
			var viewModel = _loadRepository.GetLoadItems(filter);
			return View(_mapper.Map<LoadItemsVM>(viewModel));
		}

		[Style(PageId = Dom.Page.LoadDetails)]
		public ActionResult Details(int id) {
			var details = _loadRepository.GetLoadDetails(id);
			if (details == null) {
				return NotFound();
			}
			var viewModel = _mapper.Map<LoadDetailVM>(details);
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details(LoadDetailVM viewModel) {
			if (ModelState.IsValid) {
				var load = _loadRepository.GetEntity<Load>(viewModel.Id);
				load.TeacherId = viewModel.TeacherId;
				load.SubjectId = viewModel.SubjectId;
				load.SubjectTypeId = viewModel.SubjectTypeId;
				load.GroupId = viewModel.GroupId;
				_loadRepository.UnitOfWork.SaveChanges();
				return RedirectToAction(MVC.Controller.Teacher.Details, MVC.Controller.Teacher.Name, new { id = load.TeacherId, tabId = 1 });
			}
			return Json(new {
				errors = ModelState.Values.Where(v => v.ValidationState == ModelValidationState.Invalid)
					.Select(e => e.Errors.Select(i => i.ErrorMessage))
			});
		}

		public ActionResult Create(int? teacherId = null) {
			LoadDetailVM viewModel = new LoadDetailVM();
			if (teacherId.HasValue) {
				viewModel.TeacherId = teacherId.Value;
			}
			InitLoadDetailsVM(viewModel);
			return PartialView(MVC.View.Load.Create, viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LoadDetailVM newLoadVM) {
			if (ModelState.IsValid) {
				Load load = new Load();
				load.TeacherId = newLoadVM.TeacherId;
				load.SubjectId = newLoadVM.SubjectId;
				load.SubjectTypeId = newLoadVM.SubjectTypeId;
				load.GroupId = newLoadVM.GroupId;
				var createdLoad = _loadRepository.Add(load);
				_loadRepository.UnitOfWork.SaveChanges();
				return RedirectToAction(MVC.Controller.Teacher.Details, MVC.Controller.Teacher.Name, new { id = load.TeacherId, tabId = 1 });
			}
			return Json(new { message = StyleContext.Translations.Get(Dom.Translation.Common.Error) });
		}

		[HttpPost]
		public ActionResult Delete(int id) {
			if (_loadRepository.DeleteById<Load>(id)) {
				_loadRepository.UnitOfWork.SaveChanges();
				return Json(new { message = "Load deleted succesfuly"});
			}
			return Json(new { message ="Load wasn't deleted"});
		}

		[HttpGet]
		public JsonResult GetLoads(int? teacherId = null, int? subjectId = null, int? loadId = null) {
			var itemsVM = _mapper.Map<ICollection<LoadItemVM>>(_loadRepository.GetLoads(teacherId, subjectId, loadId));
			foreach (var item in itemsVM) {
				InitLoadItemVM(item);
			}
			return Json(itemsVM);
		}

		[HttpGet]
		public JsonResult GetAvalivableLoadSelectItems(int? dayId = null, int? groupId = null, int? number = null) {
			var loadItems = _loadRepository.GetAvailableLoads(dayId, groupId, number);
			foreach (var item in loadItems) {
				item.SubjectTypeName = StyleContext.Translations.Get(_domainValueRepository.GetDomainValueNameCode(item.SubjectTypeId).Value);
			}
			return Json(_mapper.Map<ICollection<SelectItemVM>>(loadItems));
		}

		private void InitLoadDetailsVM(LoadDetailVM viewModel) {
			viewModel.SubjectTypes = _mapper.Map<ICollection<SelectItemVM>>(_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.Subject));
		}

		private void InitLoadItemVM(LoadItemVM viewModel) {
			viewModel.SubjectTypeName = StyleContext.Translations.Get(_domainValueRepository.GetDomainValueNameCode(viewModel.SubjectTypeId).Value);
		}
	}
}