namespace TimeTable.Model {
	public class LoadSelectItem : BaseModel {
		public bool Disabled { get; set; }
		public int SubjectId { get; set; }
		public string SubjectName { get; set; }
		public int SubjectTypeId { get; set; }
		public string SubjectTypeName { get; set; }
		public int TeacherId { get; set; }
		public string TeacherName { get; set; }
	}
}
