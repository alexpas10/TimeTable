namespace TimeTable.Model {
	public class TeacherItem : BaseModel {

		public string Surname { get; set; }
		public string Name { get; set; }
		public string Patronymic { get; set; }
		public int PositionId { get; set; }
		public int PositionNameCode { get; set; }
	}
}