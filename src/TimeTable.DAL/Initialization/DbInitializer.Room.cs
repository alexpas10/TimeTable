using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using TimeTable.Model;

namespace TimeTable.DAL {
	public partial class DbInitializer {
	
		public IEnumerable<Building> BuildingData { get; set; } = new List<Building> {
			new Building { Id = 1, Name = "I" }
		};

		public IEnumerable<Room> RoomData { get; set; } = new List<Room> {
			new Room { Id = 3, Name = "3", PlacesCount = 40, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 11, Name = "11", PlacesCount = 18, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 13, Name = "13", PlacesCount = 30, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 15, Name = "15", PlacesCount = 12, TypeId = Dom.DomainValue.Practice, BuildingId = 1 },
			new Room { Id = 18, Name = "18", PlacesCount = 60, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 19, Name = "19", PlacesCount = 20, TypeId = Dom.DomainValue.Practice, BuildingId = 1 },
			new Room { Id = 21, Name = "21", PlacesCount = 20, TypeId = Dom.DomainValue.Practice, BuildingId = 1 },
			new Room { Id = 22, Name = "22", PlacesCount = 60, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 23, Name = "23", PlacesCount = 40, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 24, Name = "24", PlacesCount = 40, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 26, Name = "26", PlacesCount = 30, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 27, Name = "27", PlacesCount = 30, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 28, Name = "28", PlacesCount = 20, TypeId = Dom.DomainValue.Practice, BuildingId = 1 },
			new Room { Id = 29, Name = "29", PlacesCount = 16, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 31, Name = "31", PlacesCount = 16, TypeId = Dom.DomainValue.Practice, BuildingId = 1 },
			new Room { Id = 32, Name = "32", PlacesCount = 16, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 33, Name = "33", PlacesCount = 60, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 36, Name = "36", PlacesCount = 30, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 37, Name = "37", PlacesCount = 40, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 38, Name = "38", PlacesCount = 40, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 39, Name = "39", PlacesCount = 60, TypeId = Dom.DomainValue.Lection, BuildingId = 1 },
			new Room { Id = 40, Name = "40", PlacesCount = 60, TypeId = Dom.DomainValue.Lection, BuildingId = 1 }
		};
	}
}