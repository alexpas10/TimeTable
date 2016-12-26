using AutoMapper;
using TimeTable.Common.AppConstants;
using TimeTable.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Model;
using TimeTable.Web.API.ViewModel;

namespace TimeTable.Web.API.Controllers {

	[Route("api/[controller]")]

	public class RoomController : Controller {
		private IMapper _mapper { get; set; }
		private IRoomRepository _roomRepository;
		private IDomainValueRepository _domainValueRepository;

		public RoomController(IMapper mapper, IRoomRepository roomRepository, IDomainValueRepository domainValueRepository) {
			_mapper = mapper;
			_roomRepository = roomRepository;
			_domainValueRepository = domainValueRepository;
		}

		// GET api/room?
		[HttpGet]
		public RoomItemsVM Get([FromQuery]RoomFilterVM filterVM) {
			RoomFilter filter = _mapper.Map<RoomFilter>(filterVM);
			var items = _roomRepository.GetRoomItems(filter);

			return _mapper.Map<RoomItemsVM>(items);
		}

		// GET api/room/5
		[HttpGet("{id}", Name = "GetRoom")]
		public IActionResult Get(int id) {
			var details = _roomRepository.GetRoomDetails(id);
			if (details != null)
				return new JsonResult(_mapper.Map<RoomDetailVM>(details));
			else
				return new NotFoundResult();
		}

		// PUT api/room/5
		[HttpPut("{id}")]
		public IActionResult Put([FromBody]RoomCreateVM newRoomVM) {
			if (!_domainValueRepository.CheckDomainValueOfType(newRoomVM.TypeId, Dom.DomainValueType.Subject)) {
				ModelState.AddModelError("Error", "Incorrect typeId parameter");
			}
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}
			var room = _roomRepository.GetEntity<Room>(newRoomVM.Id);
			if (room == null) {
				return NotFound();
			}
			_roomRepository.AddOrUpdate(new Room {
				BuildingId = newRoomVM.BuildingId,
				Name = newRoomVM.Name,
				PlacesCount = newRoomVM.PlacesCount,
				TypeId = newRoomVM.TypeId
			});

			_roomRepository.UnitOfWork.SaveChanges();
			return new NoContentResult();
		}

		// POST api/room
		[HttpPost]
		public IActionResult Create([FromBody]RoomCreateVM newRoomVM) {
			if (!_domainValueRepository.CheckDomainValueOfType(newRoomVM.TypeId, Dom.DomainValueType.Subject)) {
				ModelState.AddModelError("Error", "Incorrect typeId parameter");
			}
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}
			var newRoom = _roomRepository.Add<Room>(
				new Room {
					BuildingId = newRoomVM.BuildingId,
					Name = newRoomVM.Name,
					PlacesCount = newRoomVM.PlacesCount,
					TypeId = newRoomVM.TypeId
				}
			);
			_roomRepository.UnitOfWork.SaveChanges();
			return CreatedAtRoute("GetRoom", new { id = newRoom.Entity.Id }, newRoomVM);
		}

		// DELETE api/room/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id) {
			var room = _roomRepository.GetEntity<Room>(id);
			if (room == null) {
				return NotFound();
			}
			_roomRepository.Delete(room);
			_roomRepository.UnitOfWork.SaveChanges();
			return new NoContentResult();
		}
	}
}