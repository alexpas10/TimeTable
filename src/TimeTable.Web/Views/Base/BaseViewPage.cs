using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Threading.Tasks;
using TimeTable.Web.Manager;

namespace TimeTable.Web.Views {
	public class BaseViewPage<TModel> : RazorPage<TModel> {

		public string Title { get; set; }

		public override Task ExecuteAsync() {
			throw new NotImplementedException();
		}

	}
}