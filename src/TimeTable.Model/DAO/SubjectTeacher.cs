namespace TimeTable.Model {
	public class SubjectTeacher : BaseModel {

		public int SubjectId { get; set; }
		public int TeacherId { get; set; }

		public Teacher Teacher { get; set; }
		public Subject Subject { get; set; }

		public static SubjectTeacher Create(int subjectId, int teacherId) {
			return new SubjectTeacher {
				SubjectId = subjectId,
				TeacherId = teacherId
			};
		}
	}
}
