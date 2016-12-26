namespace TimeTable.Model {

	public class SubjectDetails : BaseModel {
		public string Name { get; set; }
		public string ShortName { get; set; }

		public int[] TeacherIds { get; set; }
	}
}