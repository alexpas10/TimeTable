using System.Collections.Generic;

namespace TimeTable.Model {

	public class BaseItems<TItem> where TItem : BaseModel {
		public ICollection<TItem> Items { get; set; }
	}
}