using System.Collections.Generic;

namespace TimeTable.Web.API.ViewModel {
	public class BaseItemsVM<TItem> where TItem : BaseVM {
		public ICollection<TItem> Items { get; set; }
	}
}
