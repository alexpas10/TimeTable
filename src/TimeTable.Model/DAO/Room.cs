namespace TimeTable.Model {
	public class Room : BaseModel {

		public string Name { get; set; }
		public byte PlacesCount { get; set; }
		public int BuildingId { get; set; }
		public int? TypeId { get; set; }

		public Building Building { get; set; }
	}
}
