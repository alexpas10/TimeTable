namespace TimeTable.Web.API.ViewModel {

	public class TeacherItemVM : BaseVM {
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public int PositionId { get; set; }
		public int PositionNameCode { get; set; }
	}
}