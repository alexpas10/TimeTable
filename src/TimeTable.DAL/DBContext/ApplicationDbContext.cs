using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TimeTable.Common.Manager;
using TimeTable.Model;

namespace TimeTable.DAL.DBContext {
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {

		public ApplicationDbContext() { }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) {
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			base.OnConfiguring(optionsBuilder);

			//var builder = new ConfigurationBuilder()
			//	.SetBasePath(Directory.GetCurrentDirectory())
			//	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			//var configuration = builder.Build();

			var connectionString = "Data Source=" + Directory.GetParent(Directory.GetCurrentDirectory()) + ConfigurationManager.Configuration.GetConnectionString("SQLite");
			optionsBuilder.UseSqlite(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);
		}
	}
}
