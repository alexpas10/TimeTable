namespace TimeTable.Model {

	public class ClassFilter : BaseFilter {
		public int? SubjectId { get; set; }
		public int? TeacherId { get; set; }
		public int? GroupId { get; set; }
		public int? RoomId { get; set; }
		public int? DayOfWeekId { get; set; }
	}
}