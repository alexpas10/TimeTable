using Microsoft.AspNetCore.Html;

namespace TimeTable.Web.ViewModel {
	public class TextBoxVM {
		public IHtmlContent Label { get; set; }
		public IHtmlContent Input { get; set; }
	}
}
