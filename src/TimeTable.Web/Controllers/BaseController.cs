using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTable.DAL.Repository;
using TimeTable.Web.Context;
using TimeTable.Web.Helpers;
using TimeTable.Web.Manager;

namespace TimeTable.Web.Controllers {

	public class BaseController : Controller {
		protected IDomainValueRepository _domainValueRepository;
		protected IStyleContext _styleContext;
		protected IMapper _mapper;

		public BaseController() {
			_domainValueRepository = ServicesAccesor.GetService<IDomainValueRepository>();
			_styleContext = ServicesAccesor.GetService<IStyleContext>();
			_mapper = ServicesAccesor.GetService<IMapper>();
		}

		public IStyleContext StyleContext {
			get {
				return _styleContext;
			}
		}



		public ActionResult ToastMessage(string message) {
			return PartialView(MVC.View.Shared.Toast, message);
		}

		public JsonResult JsonMessage(string message) {
			return Json(new { message = message });
		}
	}
}
