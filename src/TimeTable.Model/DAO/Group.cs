using System.Collections.Generic;

namespace TimeTable.Model {
	public class Group : BaseModel {

		public string Name { get; set; }
		public byte? Year { get; set; }
		public byte? StudentsCount { get; set; }
		public int TypeId { get; set; }

		// public ICollection<Subject> Subjects { get; set; }
	}
}
