using System.Collections.Generic;
using TimeTable.DAL.DBContext;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {
	public interface IRoomRepository : IRepository<EntityDbContext> {
		RoomItems GetRoomItems(RoomFilter filter);
		RoomItems GetRoomItemsWithSQL(RoomFilter filter);
		RoomDetails GetRoomDetails(int id);
		ICollection<SelectItem> GetAvailableRooms(int? dayId = null, int? number = null);
	}
}
