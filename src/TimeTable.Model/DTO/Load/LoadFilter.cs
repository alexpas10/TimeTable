namespace TimeTable.Model {

	public class LoadFilter : BaseFilter {
		public int SubjectId { get; set; }
		public int SubjectTypeId { get; set; }
		public int TeacherId { get; set; }
		public int GroupId { get; set; }
	}
}