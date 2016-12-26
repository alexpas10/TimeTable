using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.DAL.Repository;
using TimeTable.Model;
using TimeTable.Web.ActionFilter;
using TimeTable.Web.Manager;
using TimeTable.Web.ViewModel;

namespace TimeTable.Web.Controllers {

	public class RoomController : BaseController {
		private IRoomRepository _roomRepository;

		public RoomController(IRoomRepository roomRepository) {
			_roomRepository = roomRepository;
		}

		[Style(PageId = Dom.Page.RoomList)]
		public ActionResult Index(RoomFilterVM filterVM) {
			RoomFilter filter = _mapper.Map<RoomFilter>(filterVM);
			var viewModel = _mapper.Map<RoomItemsVM>(_roomRepository.GetRoomItems(filter));
			InitRoomItemsVM(viewModel);
			return View(viewModel);
		}

		[Style(PageId = Dom.Page.RoomDetails)]
		public ActionResult Details(int id) {
			var details = _roomRepository.GetRoomDetails(id);
			if (details == null) {
				return NotFound();
			}
			var viewModel = _mapper.Map<RoomDetailVM>(details);
			InitRoomDetailsVM(viewModel);
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Details(RoomDetailVM viewModel) {
			if (viewModel.TypeId.HasValue && !_domainValueRepository.CheckDomainValueOfType(viewModel.TypeId.Value, Dom.DomainValueType.Subject)) {
				ModelState.AddModelError("Error", "Incorrect type");
			}
			if (ModelState.IsValid) {
				var room = _roomRepository.GetEntity<Room>(viewModel.Id);
				room.Name = viewModel.Name;
				room.BuildingId = viewModel.BuildingId;
				room.TypeId = viewModel.TypeId;
				room.PlacesCount = viewModel.PlacesCount;
				_roomRepository.UnitOfWork.SaveChanges();
			}
			return RedirectToAction(MVC.Controller.Room.Details, new { id = viewModel.Id });
		}

		public ActionResult Create() {
			RoomDetailVM viewModel = new RoomDetailVM();
			InitRoomDetailsVM(viewModel);
			return PartialView(MVC.View.Room.Create, viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(RoomDetailVM newRoomVM) {
			if (newRoomVM.TypeId.HasValue && !_domainValueRepository.CheckDomainValueOfType(newRoomVM.TypeId.Value, Dom.DomainValueType.Subject)) {
				ModelState.AddModelError("Error", "Incorrect type");
			}
			if (ModelState.IsValid) {
				_roomRepository.Add<Room>(
					new Room {
						BuildingId = newRoomVM.BuildingId,
						Name = newRoomVM.Name,
						PlacesCount = newRoomVM.PlacesCount,
						TypeId = newRoomVM.TypeId
					}
				);
				_roomRepository.UnitOfWork.SaveChanges();
			}
			return RedirectToAction(MVC.Controller.Room.List);
		}

		// POST: Room/Delete/5
		[HttpPost]
		public ActionResult Delete(int id) {
			if (_roomRepository.DeleteById<Room>(id)) {
				_roomRepository.UnitOfWork.SaveChanges();
				return RedirectToAction(MVC.Controller.Room.List);
			}
			return NotFound();
		}

		private void InitRoomItemsVM(RoomItemsVM viewModel) {
			foreach (var item in viewModel.Items) {
				item.TypeName = StyleContext.Translations.Get(item.TypeNameCode);
			}
		}

		[HttpGet]
		public JsonResult GetAvalivableRoomSelectItems(int? dayId = null, int? number = null) {
			return Json(_roomRepository.GetAvailableRooms(dayId, number));
		}

		private void InitRoomDetailsVM(RoomDetailVM viewModel) {
			viewModel.TypeName = StyleContext.Translations.Get(viewModel.TypeNameCode);
			viewModel.TypeItems = _mapper.Map<ICollection<SelectItemVM>>(_domainValueRepository.GetDomainValuesByType(Dom.DomainValueType.Subject));
			viewModel.BuildingItems = new List<SelectItemVM> {
				new SelectItemVM {
					Value = "1",
					Id = 1
				}
			};
		}
	}
}