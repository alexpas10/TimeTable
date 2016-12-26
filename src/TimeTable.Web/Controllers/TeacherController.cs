using Microsoft.AspNetCore.Mvc;
using TimeTable.Common.AppConstants;
using TimeTable.DAL.Repository;
using TimeTable.Model;
using TimeTable.Web.ActionFilter;
using TimeTable.Web.Manager;
using TimeTable.Web.ViewModel;
using System.Collections.Generic;
using TimeTable.Common;

namespace TimeTable.Web.Controllers {

	public class TeacherController : BaseController {
		private ITeacherRepository _teacherRepository;
		private ISubjectRepository _subjectRepository;

		public TeacherController(ITeacherRepository TeacherRepository, ISubjectRepository SubjectRepository) {
			_teacherRepository = TeacherRepository;
			_subjectRepository = SubjectRepository;
		}

		[Style(PageId = Dom.Page.TeacherList)]
		public ActionResult Index(TeacherFilterVM filterVM) {
			TeacherFilter filter = _mapper.Map<TeacherFilter>(filterVM);
			var items = _teacherRepository.GetTeacherItems(filter);
			TeacherItemsVM viewModel = _mapper.Map<TeacherItemsVM>(items);
			InitTeacherItemsVM(viewModel);
			return View(viewModel);
		}

		[Style(PageId = Dom.Page.TeacherDetails)]
		public ActionResult Details(int id, int tabId = 0) {

			var details = _teacherRepository.GetTeacherDetails(id);
			if (details == null) {
				return NotFound();
			}
			var viewModel = _mapper.Map<TeacherDetailVM>(details);
			InitTeacherDetailsVM(viewModel);
			ViewData[MVC.ViewData.TabId] = tabId;
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details([FromForm]TeacherDetailVM viewModel) {
			if (ModelState.IsValid) {
				var teacher = _teacherRepository.GetEntity<Teacher>(viewModel.Id);
				teacher.Name = viewModel.Name;
				teacher.Surname = viewModel.Surname;
				teacher.Patronymic = viewModel.Patronymic;
				teacher.PositionId = viewModel.PositionId.Value;
				_teacherRepository.UpdateSubjects(teacher, viewModel.SelectedSubjects);

				_teacherRepository.UnitOfWork.SaveChanges();
			}
			return RedirectToAction(MVC.Controller.Teacher.Details, new { id = viewModel.Id });
		}

		public ActionResult Create() {
			TeacherDetailVM viewModel = new TeacherDetailVM();
			viewModel.PositionItems = _mapper.Map<ICollection<SelectItemVM>>(_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.TeachersPosition));
			return PartialView(MVC.View.Teacher.Create, viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(TeacherDetailVM newTeacherVM) {
			if (newTeacherVM.PositionId.HasValue && !_domainValueRepository.CheckDomainValueOfType(newTeacherVM.PositionId.Value, Dom.DomainValueType.TeachersPosition)) {
				ModelState.AddModelError("Error", $"Incorrect {nameof(newTeacherVM.PositionId)} value");
			}
			if (ModelState.IsValid) {
				var newTeacher = _teacherRepository.Add(
					new Teacher {
						Name = newTeacherVM.Name,
						Surname = newTeacherVM.Surname,
						Patronymic = newTeacherVM.Patronymic,
						PositionId = newTeacherVM.PositionId.Value
					}
				);
				_teacherRepository.UnitOfWork.SaveChanges();
			}
			return RedirectToAction(MVC.Controller.Teacher.List);
		}

		[HttpPost]
		public ActionResult Delete(int id) {
			if (_teacherRepository.DeleteById<Teacher>(id)) {
				_teacherRepository.UnitOfWork.SaveChanges();
				return RedirectToAction(MVC.Controller.Teacher.List);
			}
			return NotFound();
		}

		[HttpGet]
		public JsonResult GetTeachers(int? subjectId = null) {
			return Json(_teacherRepository.GetTeachers(subjectId));
		}

		private void InitTeacherDetailsVM(TeacherDetailVM viewModel) {
			viewModel.FormattedName = Format.FormattedShortName(viewModel.Surname, viewModel.Name, viewModel.Patronymic);
			viewModel.PositionName = StyleContext.Translations.Get(_domainValueRepository.GetDomainValueNameCode(viewModel.PositionId.Value).Value);
			viewModel.PositionItems = _mapper.Map<ICollection<SelectItemVM>>(_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.TeachersPosition));
			viewModel.SubjectTypeItems = _mapper.Map<ICollection<SelectItemVM>>(_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.Subject));
		}

		private void InitTeacherItemsVM(TeacherItemsVM viewModel) {
			foreach (var item in viewModel.Items) {
				item.PositionName = StyleContext.Translations.Get(_domainValueRepository.GetDomainValueNameCode(item.PositionId).Value);
				item.FormattedName = Format.FormattedFullName(item.Surname, item.Name, item.Patronymic);
			}
		}
	}
}