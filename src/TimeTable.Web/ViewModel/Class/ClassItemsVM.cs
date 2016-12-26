using System.Collections.Generic;
using TimeTable.Model;

namespace TimeTable.Web.ViewModel {

	public class ClassItemsVM : BaseItemsVM<ClassItemVM> {
		public ICollection<KeyValue> WeekAlternations { get; set; }
		public ICollection<KeyValue> Days { get; set; }
		public ICollection<KeyValue> Groups { get; set; }
		public ICollection<KeyValue> Numbers { get; set; }
	}
}