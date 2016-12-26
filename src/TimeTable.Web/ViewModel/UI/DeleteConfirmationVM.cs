using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTable.Web.ViewModel {
	public class DeleteConfirmationVM : BaseVM {
		public string Action { get; set; }
		public string Controller { get; set; }
	}
}
