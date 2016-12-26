using System.Collections.Generic;

namespace TimeTable.Model {
	public class GroupDetails : BaseModel {

		public string Name { get; set; }
		public byte? Year { get; set; }
		public byte? StudentsCount { get; set; }

		public ICollection<KeyValue> SubGroups { get; set; }
		public ICollection<KeyValue> ParentGroups { get; set; }
	}
}
