namespace TimeTable.Model {
	public class RoomItem : BaseModel {
		public string Name { get; set; }
		public int PlacesCount { get; set; }
		public string BuildingName { get; set; }
		public int? TypeNameCode { get; set; }
	}
}