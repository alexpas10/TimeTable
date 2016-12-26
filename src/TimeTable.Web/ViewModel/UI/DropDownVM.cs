using System;
using Microsoft.AspNetCore.Html;


namespace TimeTable.Web.ViewModel {
	public class DropDownVM {
		public IHtmlContent Label { get; set; }
		public IHtmlContent Input { get; set; }
		public IHtmlContent HiddenOptions { get; set; }
		
	}
}
