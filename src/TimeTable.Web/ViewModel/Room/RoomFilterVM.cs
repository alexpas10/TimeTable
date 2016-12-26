namespace TimeTable.Web.ViewModel {
	public class RoomFilterVM : BaseFilterVM {
		public string Name { get; set; }
		public int? PlacesCountFrom { get; set; }
		public int? PlacesCountTo { get; set; }
		public int? BuildingId { get; set; }
		public int? TypeId { get; set; }
	}
}
