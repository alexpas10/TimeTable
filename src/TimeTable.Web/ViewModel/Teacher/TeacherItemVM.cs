namespace TimeTable.Web.ViewModel {

	public class TeacherItemVM : BaseVM {
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public int PositionId { get; set; }
		public string PositionName { get; set; }
		public string FormattedName { get; internal set; }
	}
}