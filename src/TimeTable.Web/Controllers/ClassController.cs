using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using TimeTable.Common.AppConstants;
using TimeTable.DAL.Repository;
using TimeTable.Model;
using TimeTable.Web.ActionFilter;
using TimeTable.Web.Manager;
using TimeTable.Web.ViewModel;
using TimeTable.Web.Extension;
using System;
using System.Collections.Generic;
using TimeTable.Common;

namespace TimeTable.Web.Controllers {

	public class ClassController : BaseController {
		private IClassRepository _classRepository;
		private IRoomRepository _roomRepository;
		private ILoadRepository _loadRepository;
		private IGroupRepository _groupRepository;

		public ClassController(IClassRepository ClassRepository, IRoomRepository roomRepository, ILoadRepository loadRepository, IGroupRepository groupRepository) {
			_classRepository = ClassRepository;
			_roomRepository = roomRepository;
			_loadRepository = loadRepository;
			_groupRepository = groupRepository;
		}

		[Style(PageId = Dom.Page.ClassList)]
		public ActionResult Index(ClassFilterVM filterVM) {
			ClassFilter filter = _mapper.Map<ClassFilter>(filterVM);
			var viewModel = _mapper.Map<ClassItemsVM>(_classRepository.GetClassItems(filter));
			InitClassItemsVM(viewModel);
			return View(viewModel);
		}


		[HttpGet]
		public ActionResult List(ClassFilterVM filterVM) {
			ClassFilter filter = _mapper.Map<ClassFilter>(filterVM);
			var viewModel = _classRepository.GetClassItems(filter);
			return Json(viewModel.Items);
		}

		[Style(PageId = Dom.Page.ClassDetails)]
		public ActionResult Details(int id) {
			var details = _classRepository.GetClassDetails(id);
			if (details == null) {
				return NotFound();
			}
			var viewModel = _mapper.Map<ClassDetailVM>(details);
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details(ClassDetailVM viewModel) {
			if (ModelState.IsValid) {
				var classEntity = _classRepository.GetEntity<Class>(viewModel.Id);
				_classRepository.UnitOfWork.SaveChanges();
				return View();
			}
			return Json(new {
				errors = ModelState.Values.Where(v => v.ValidationState == ModelValidationState.Invalid)
					.Select(e => e.Errors.Select(i => i.ErrorMessage))
			});
		}

		public ActionResult Create(int? dayId = null, int? groupId = null, int? number = null) {
			ClassCreateVM viewModel = new ClassCreateVM {
				DayOfWeekId = dayId,
				GroupId = groupId,
				Number = number
			};

			if (groupId.HasValue) {
				var group = _classRepository.GetEntity<Group>(groupId.Value);
				viewModel.GroupFormattedName = StyleFormat.FormattedGroupName(group.Name, group.StudentsCount.ToString());
			}

			viewModel.WeekAlternations = _mapper.Map<ICollection<SelectItemVM>>(_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.WeeksAlternation));
			viewModel.Rooms = _mapper.Map<ICollection<SelectItemVM>>(_roomRepository.GetRoomItems(new RoomFilter()).Items);

			return PartialView(MVC.View.Class.Create, viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ClassDetailVM newClassVM) {
			if (ModelState.IsValid) {
				Class classEntity = new Class();
				var createdClass = _classRepository.Add(classEntity);
				_classRepository.UnitOfWork.SaveChanges();
				return View();
			}
			return Json(new { message = StyleContext.Translations.Get(Dom.Translation.Common.Error) });
		}

		[HttpPost]
		public ActionResult Delete(int id) {
			if (_classRepository.DeleteById<Class>(id)) {
				_classRepository.UnitOfWork.SaveChanges();
				return Json(new { message = "Class deleted succesfuly" });
			}
			return Json(new { message = "Class wasn't deleted" });
		}


		[HttpGet]
		public JsonResult Days() {
			return Json(_mapper.Map<ICollection<KeyValue>>(_domainValueRepository.GetWorkingDays()));
		}

		[HttpGet]
		public JsonResult WeekAlternations(int? dayId = null, int? groupId = null, int? number = null) {
			return Json(_mapper.Map<ICollection<KeyValue>>(_domainValueRepository.GetAvailableWeekAlternations(dayId, groupId, number)));
		}


		private void InitClassItemVM(ClassItemVM viewModel) {
			viewModel.WeekAlternationName = StyleContext.Translations.Get(_domainValueRepository.GetDomainValueNameCode(viewModel.WeekAlternationId).Value);
			viewModel.DayOfWeekName = StyleContext.Translations.Get(_domainValueRepository.GetDomainValueNameCode(viewModel.DayOfWeekId).Value);
		}

		private void InitClassItemsVM(ClassItemsVM viewModel) {
			viewModel.Days = _mapper.Map<ICollection<KeyValue>>(_domainValueRepository.GetWorkingDays());
			viewModel.WeekAlternations = _mapper.Map<ICollection<KeyValue>>(_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.WeeksAlternation));
			viewModel.Groups = _groupRepository.GetGroups()
				.Select(s => new KeyValue {
					Id = s.Id,
					Value = s.Name,
				}).ToList();
			viewModel.Numbers = new List<KeyValue>();
			for (int i = 1; i <= 6; i++) {
				viewModel.Numbers.Add(new KeyValue { Id = i, Value = i.ToString() });
			}
		}
	}
}