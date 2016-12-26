using System.Collections.Generic;
using TimeTable.Model;

namespace TimeTable.Web.ViewModel {

	public class LoadItemVM : BaseVM {

		public int SubjectId { get; set; }
		public string SubjectName { get; set; }
		public ICollection<KeyValue> Subjects { get; set; }

		public int SubjectTypeId { get; set; }
		public string SubjectTypeName { get; set; }
		public ICollection<KeyValue> SubjectTypes { get; set; }

		public int TeacherId { get; set; }
		public string TeacherName { get; set; }
		public ICollection<KeyValue> Teachers { get; set; }

		public int GroupId { get; set; }
		public string GroupName { get; set; }
		public ICollection<KeyValue> Groups { get; set; }
	}
}