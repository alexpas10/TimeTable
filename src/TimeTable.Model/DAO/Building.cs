using System.Collections.Generic;

namespace TimeTable.Model {
	public class Building : BaseModel {

		public string Name { get; set; }

		public ICollection<Room> Rooms { get; set; }
	}
}
