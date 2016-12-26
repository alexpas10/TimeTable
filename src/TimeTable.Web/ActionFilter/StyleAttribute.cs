using Microsoft.AspNetCore.Mvc.Filters;
using TimeTable.Model;
using TimeTable.Web.Controllers;
using TimeTable.Web.Manager;

namespace TimeTable.Web.ActionFilter {

	public class StyleAttribute : ActionFilterAttribute {

		public int PageId { get; set; }

		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			BaseController controller = filterContext.Controller as BaseController;
			controller.ModelState?.Clear();

			controller.StyleContext.InitPage(PageId);

			if (controller.StyleContext.Page != null) {
				Page page = controller.StyleContext.Page;
				controller.ViewBag.Title = controller.StyleContext.Translations.Get(page.TitleCode);
				controller.ViewBag.IsDetailPage = page.IsDetailPage;
			}

			if (controller.StyleContext.Page == null) 
				filterContext.Result = controller.Forbid();
		}
	}
}
