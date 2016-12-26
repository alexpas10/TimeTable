namespace TimeTable.Model {

	public class TeacherFilter : BaseFilter {
		public string Name { get; set; }
		public int? PlacesCountFrom { get; set; }
		public int? PlacesCountTo { get; set; }
		public int? BuildingId { get; set; }
		public int? TypeId { get; set; }
	}
}