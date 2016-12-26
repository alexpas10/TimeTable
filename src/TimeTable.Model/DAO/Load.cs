namespace TimeTable.Model {
	public class Load : BaseModel {

		public int SubjectId { get; set; }
		public int SubjectTypeId { get; set; }
		public int GroupId { get; set; }
		public int HoursPerWeek { get; set; }
		public int TeacherId { get; set; }

		public Subject Subject { get; set; }
		public Teacher Teacher { get; set; }
		public Group Group { get; set; }
	}
}
