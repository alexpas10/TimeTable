using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Common.AppConstants;
using TimeTable.DAL.Repository;
using TimeTable.Model;
using TimeTable.Web.ActionFilter;
using TimeTable.Web.Manager;
using TimeTable.Web.ViewModel;
using System.Collections.Generic;

namespace TimeTable.Web.Controllers {

	public class SubjectController : BaseController {
		private ITeacherRepository _teacherRepository;
		private ISubjectRepository _subjectRepository;

		public SubjectController(ITeacherRepository TeacherRepository, ISubjectRepository SubjectRepository) {
			_teacherRepository = TeacherRepository;
			_subjectRepository = SubjectRepository;
		}

		[Style(PageId = Dom.Page.SubjectList)]
		public ActionResult Index(SubjectFilterVM filterVM) {
			SubjectFilter filter = _mapper.Map<SubjectFilter>(filterVM);
			var viewModel = _subjectRepository.GetSubjectItems(filter);
			return View(_mapper.Map<SubjectItemsVM>(viewModel));
		}

		[Style(PageId = Dom.Page.SubjectDetails)]
		public ActionResult Details(int id) {

			var details = _subjectRepository.GetSubjectDetails(id);
			if (details == null) {
				return NotFound();
			}
			var viewModel = _mapper.Map<SubjectDetailVM>(details);
			InitSubjectDetailsVM(viewModel);
			return View(viewModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details([FromForm]SubjectDetailVM viewModel) {
			if (ModelState.IsValid) {
				var subject = _subjectRepository.GetEntity<Subject>(viewModel.Id, s => s.Teachers);
				subject.Name = viewModel.Name;
				subject.ShortName = viewModel.ShortName;
				_subjectRepository.UpdateTeachers(subject, viewModel.SelectedTeachers);

				_subjectRepository.UnitOfWork.SaveChanges();
			}
			return RedirectToAction(MVC.Controller.Subject.Details, new { id = viewModel.Id });
		}

		public ActionResult Create() {
			SubjectDetailVM viewModel = new SubjectDetailVM();
			return PartialView(MVC.View.Subject.Create, viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(SubjectDetailVM newSubjectVM) {
			if (ModelState.IsValid) {
				var newSubject = _subjectRepository.Add(
					new Subject {
						Name = newSubjectVM.Name,
						ShortName = newSubjectVM.ShortName
					}
				);
				_subjectRepository.UnitOfWork.SaveChanges();
			}
			return RedirectToAction(MVC.Controller.Subject.List);
		}

		[HttpPost]
		public ActionResult Delete(int id) {
			if (_subjectRepository.DeleteById<Subject>(id)) {
				_subjectRepository.UnitOfWork.SaveChanges();
				return RedirectToAction(MVC.Controller.Subject.List);
			}
			return NotFound();
		}

		[HttpGet]
		public JsonResult GetSubjects(int? teacherId = null) {
			return Json(_subjectRepository.GetSubjects(teacherId));
		}

		private void InitSubjectDetailsVM(SubjectDetailVM viewModel) {
			viewModel.TeacherItems = _mapper.Map<ICollection<SelectItemVM>>(_teacherRepository.GetTeachers());
		}
	}
}