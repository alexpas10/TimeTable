using Microsoft.AspNetCore.Mvc;
using TimeTable.Common.AppConstants;
using TimeTable.Web.ActionFilter;

namespace TimeTable.Web.Controllers {

	public class HomeController : BaseController {

		[Style(PageId = Dom.Page.Home)]
		public IActionResult Index() {
			return View();
		}

		public IActionResult About() {
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact() {
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error() {
			return View();
		}
	}
}