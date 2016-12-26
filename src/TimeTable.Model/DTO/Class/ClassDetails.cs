using System.Collections.Generic;

namespace TimeTable.Model {
	public class ClassDetails : BaseModel {

		public int SubjectId { get; set; }
		public string SubjectName { get; set; }
		public int SubjectTypeId { get; set; }
		public int TeacherId { get; set; }
		public string TeacherName { get; set; }
		public int GroupId { get; set; }
		public string GroupName { get; set; }

		public ICollection<KeyValue> Subjects { get; set; }
		public ICollection<KeyValue> Teachers { get; set; }
		public ICollection<KeyValue> Groups { get; set; }
	}
}
