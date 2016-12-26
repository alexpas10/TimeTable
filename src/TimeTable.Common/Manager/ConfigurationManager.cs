using Microsoft.Extensions.Configuration;
using System.IO;

namespace TimeTable.Common.Manager {
	public class ConfigurationManager {

		private static IConfigurationRoot _configuration;
		public static IConfigurationRoot Configuration { 
			get {
				return _configuration ?? Build();
			}
			set {
				_configuration = value;
			}
		}

		public static IConfigurationRoot Build() {
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				
			var Configuration = builder.Build();
			return Configuration;
		}
	}
}
