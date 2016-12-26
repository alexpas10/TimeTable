namespace TimeTable.Model {
	public class RoomDetails : BaseModel {
		public string Name { get; set; }
		public int PlacesCount { get; set; }
		public int BuildingId { get; set; }
		public string BuildingName { get; set; }
		public int? TypeId { get; set; }
		public int? TypeNameCode { get; set; }
	}
}
