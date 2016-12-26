using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TimeTable.Web.API.Middleware {
	public class UsingCORSMiddleware {

		private readonly RequestDelegate _next;

		public UsingCORSMiddleware(RequestDelegate next) {
			_next = next;
		}

		public async Task Invoke(HttpContext context) {

			IHeaderDictionary headers = context.Response.Headers;

			headers["Access-Control-Allow-Origin"] = "*";
			headers["Access-Control-Allow-Headers"] = "*";
			headers["Access-Control-Allow-Methods"] = "*";

			await _next.Invoke(context);
		}
	}
}
