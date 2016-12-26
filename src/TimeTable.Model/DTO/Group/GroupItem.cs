namespace TimeTable.Model {
	public class GroupItem : BaseModel {
		public string Name { get; set; }
		public byte? Year { get; set; }
		public byte? StudentsCount { get; set; }
	}
}