using System.Collections.Generic;

namespace TimeTable.Web.ViewModel {
	public class BaseItemsVM<TItem> where TItem : BaseVM {
		public ICollection<TItem> Items { get; set; }
	}
}
