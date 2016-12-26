using System.Collections.Generic;

namespace TimeTable.Model {
	public class Subject : BaseModel {

		public string Name { get; set; }
		public string ShortName { get; set; }

		public ICollection<SubjectTeacher> Teachers { get; set; }
	}
}
