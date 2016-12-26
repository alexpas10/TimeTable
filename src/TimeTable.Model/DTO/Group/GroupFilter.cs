namespace TimeTable.Model {

	public class GroupFilter : BaseFilter {
		public string Name { get; set; }
		public int? Year { get; set; }
		public int? StudentsCountFrom { get; set; }
		public int? StudentsCountTo { get; set; }
	}
}