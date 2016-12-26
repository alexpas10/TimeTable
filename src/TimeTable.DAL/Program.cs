using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.Repository;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;

namespace TimeTable.DAL {

	public class Program {

		public static void Main(string[] args) {
			var services = new ServiceCollection();
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();
			services.AddDbContext<EntityDbContext>();
			services.AddDbContext<ApplicationDbContext>();
			services.AddTransient<DbContext, EntityDbContext>();
			services.AddTransient<IUnitOfWork<DbContext>, UnitOfWork<DbContext>>();
			services.AddTransient<IUnitOfWork<EntityDbContext>, UnitOfWork<EntityDbContext>>();
			services.AddTransient<IRepository<DbContext>, BaseRepository<DbContext>>();

			var serviceProvider = services.BuildServiceProvider();

			if (args.Length > 0 && args[0] == "init") {
				Console.WriteLine("Initialization started");

				DbInitializer initializer = new DbInitializer(serviceProvider.GetService<IRepository<DbContext>>());

				if (args.Length > 1 && !string.IsNullOrEmpty(args[1])) {
					initializer.UpdateTable(args[1]);
				} else {
					initializer.InitializeAll();
					initializer.InitializeIdentity(serviceProvider.GetService<DbContext>(),
						serviceProvider.GetService<UserManager<ApplicationUser>>(),
						serviceProvider.GetService<RoleManager<IdentityRole>>()
					);
				}
				Console.WriteLine("Initialization done.");
			}
		}
	}
}