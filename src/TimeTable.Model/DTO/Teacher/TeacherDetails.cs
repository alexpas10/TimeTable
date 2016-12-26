namespace TimeTable.Model {

	public class TeacherDetails : BaseModel {
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public int PositionId { get; set; }
		public int PositionNameCode { get; set; }

		public int[] SubjectIds { get; set; }
	}
}