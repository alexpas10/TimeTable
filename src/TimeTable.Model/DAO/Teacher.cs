using System.Collections.Generic;

namespace TimeTable.Model {
	public class Teacher : BaseModel {

		public string Surname { get; set; }
		public string Name { get; set; }
		public string Patronymic { get; set; }
		public int PositionId { get; set; }

		public ICollection<SubjectTeacher> Subjects { get; set; }

		public static Teacher Create(int id, string surname, string name, string patronymic, int positionId) {
			return new Teacher {
				Id = id,
				Surname = surname,
				Name = name,
				Patronymic = patronymic,
				PositionId = positionId
			};
		}
	}
}
