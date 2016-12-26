using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TimeTable.Common.AppConstants;
using TimeTable.DAL;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.Repository;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;
using TimeTable.Web.Context;
using TimeTable.Web.Helpers;
using TimeTable.Web.Manager;
using TimeTable.Web.Mapping;
using TimeTable.Web.Provider;
using TimeTable.Web.Services;

namespace TimeTable.Web {

	public class Startup {
		private MapperConfiguration _mapperConfiguration { get; set; }

		public IConfigurationRoot Configuration { get; }

		public Startup(IHostingEnvironment env) {
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

			if (env.IsDevelopment()) {
				builder.AddUserSecrets();
			}

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
		}


		public IServiceProvider ConfigureServices(IServiceCollection services) {
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddMvc(config => {
				config.ModelBinderProviders.Insert(0, new MultipleSelectModelBinderProvider());
			})
			.AddMvcOptions(m => m.ModelMetadataDetailsProviders.Add(new MetadataProvider()));

			services.AddTransient<IEmailSender, AuthMessageSender>();
			services.AddTransient<ISmsSender, AuthMessageSender>();

			services.AddSingleton<IMapper>(s => _mapperConfiguration.CreateMapper());
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddDbContext<EntityDbContext>();
			services.AddDbContext<ApplicationDbContext>();
			services.AddTransient<DbContext, EntityDbContext>();
			services.AddTransient<IUnitOfWork<DbContext>, UnitOfWork<DbContext>>();
			services.AddTransient<IUnitOfWork<EntityDbContext>, UnitOfWork<EntityDbContext>>();
			services.AddTransient<IRepository<DbContext>, BaseRepository<DbContext>>();
			services.AddTransient<IDomainValueRepository, DomainValueRepository>();
			services.AddTransient<IRoomRepository, RoomRepository>();
			services.AddTransient<IGroupRepository, GroupRepository>();
			services.AddTransient<ISubjectRepository, SubjectRepository>();
			services.AddTransient<ITeacherRepository, TeacherRepository>();
			services.AddTransient<ILoadRepository, LoadRepository>();
			services.AddTransient<IClassRepository, ClassRepository>();
			services.AddTransient<ITranslationRepository, TranslationRepository>();
			services.AddTransient<IPageRepository, PageRepository>();

			services.AddTransient<ITranslationManager, TranslationManager>();
			services.AddTransient<IStyleContext, StyleContext>();

			var serviceProvider = services.BuildServiceProvider();

			StyleContext.Current = serviceProvider.GetService<IStyleContext>();
			ServicesAccesor.ServiceProvider = serviceProvider;

			_mapperConfiguration = new MapperConfiguration(config => {
				config.AddProfile(new DefaultProfile());
			});
			return serviceProvider;
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
			IRepository<DbContext> repository
		) {
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
				app.UseBrowserLink();
			} else {
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseIdentity();

			app.UseMvc(routes => {
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			// var initializer = new DbInitializer(repository);
			// initializer.InitializeIdentity(appDbContext, userManager, roleManager);
		}
	}
}