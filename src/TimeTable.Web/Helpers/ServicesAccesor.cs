using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace TimeTable.Web.Helpers {

	public class ServicesAccesor {

		public static IServiceProvider ServiceProvider { get; set; }

		public static T GetService<T>() where T : class {
			return ServiceProvider.GetService<T>();
		}

		public static IEnumerable<T> GetServices<T>() where T : class {
			return ServiceProvider.GetServices<T>();
		}
	}
}