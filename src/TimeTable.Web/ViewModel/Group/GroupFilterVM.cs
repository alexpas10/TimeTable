namespace TimeTable.Web.ViewModel {

	public class GroupFilterVM : BaseFilterVM {
		public string Name { get; set; }
		public byte? Year { get; set; }
		public byte? StudentsCountFrom { get; set; }
		public byte? StudentsCountTo { get; set; }
	}
}