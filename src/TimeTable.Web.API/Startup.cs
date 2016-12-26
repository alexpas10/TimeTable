using AutoMapper;
using TimeTable.DAL;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.Repository;
using TimeTable.DAL.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TimeTable.Web.API.Mapping;
using TimeTable.Web.API.Middleware;

namespace TimeTable.Web.API {
	public class Startup {

		private MapperConfiguration _mapperConfiguration { get; set; }

		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env) {
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

			if (env.IsEnvironment("Development")) {
				// This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
				builder.AddApplicationInsightsSettings(developerMode: true);
			}

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();

			_mapperConfiguration = new MapperConfiguration(cfg => {
				cfg.AddProfile(new DefaultProfile());
			});
		}

		public void ConfigureServices(IServiceCollection services) {
			services.AddApplicationInsightsTelemetry(Configuration);
			services.AddMvc();

			services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());

			services.AddDbContext<EntityDbContext>();
			services.AddTransient<DbContext, EntityDbContext>();
			services.AddTransient<IUnitOfWork<DbContext>, UnitOfWork<DbContext>>();
			services.AddTransient<IUnitOfWork<EntityDbContext>, UnitOfWork<EntityDbContext>>();
			services.AddTransient<IRepository<DbContext>, BaseRepository<DbContext>>();
			services.AddTransient<IDomainValueRepository, DomainValueRepository>();
			services.AddTransient<IRoomRepository, RoomRepository>();
			services.AddTransient<ITeacherRepository, TeacherRepository>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
			DbContext context) {
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMiddleware<UsingCORSMiddleware>();

			app.UseMvc();
		}
	}
}
