using TimeTable.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TimeTable.Common.Manager;

namespace TimeTable.DAL.DBContext {
	public class EntityDbContext : DbContext {

		public EntityDbContext() { }

		public EntityDbContext(DbContextOptions<EntityDbContext> options)
			: base(options) { }

		public string ConnectionString { get; private set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			base.OnConfiguring(optionsBuilder);

			ConnectionString = "Data Source=" + Directory.GetParent(Directory.GetCurrentDirectory()) + ConfigurationManager.Configuration.GetConnectionString("SQLite");
			optionsBuilder.UseSqlite(ConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);

			builder.Entity<Building>(m => {
				m.ToTable("Building");
				m.Property(p => p.Name).HasMaxLength(32);
				m.HasMany(t => t.Rooms).WithOne(r => r.Building);
			});

			builder.Entity<Class>(m => {
				m.ToTable("Class");
				m.HasOne(t => t.Load);
			});

			builder.Entity<DomainValue>(m =>
				m.ToTable("DomainValue")
			);

			builder.Entity<DomainValueType>(m =>
				m.ToTable("DomainValueType")
			);

			builder.Entity<Group>(m => {
				m.ToTable("Group");
				m.Property(p => p.Name).HasMaxLength(128);
			});

			builder.Entity<GroupRelation>(m => {
				m.ToTable("GroupRelation");
				m.HasOne(t => t.Group);
				m.HasOne(t => t.ParentGroup);
			});

			builder.Entity<Room>(m => {
				m.ToTable("Room");
				m.HasOne(p => p.Building).WithMany(b => b.Rooms);
				m.Property(p => p.Name).HasMaxLength(32);
			});

			builder.Entity<SubjectTeacher>(m => {
				m.ToTable("SubjectTeacher");
				//m.HasKey(t => new { t.SubjectId, t.TeacherId });
				m.HasKey(t => t.Id);
			});

			builder.Entity<SubjectTeacher>(m => {
				m.HasOne(t => t.Teacher)
				.WithMany(p => p.Subjects)
				.HasForeignKey(t => t.TeacherId);
			});

			builder.Entity<SubjectTeacher>(m => {
				m.HasOne(t => t.Subject)
				.WithMany(p => p.Teachers)
				.HasForeignKey(t => t.SubjectId);
			});

			builder.Entity<Subject>(m => {
				m.ToTable("Subject");
			});


			builder.Entity<Teacher>(m => {
				m.ToTable("Teacher");
			});

			builder.Entity<Load>(m => {
				m.ToTable("Load");
				m.HasOne(t => t.Subject);
				m.HasOne(t => t.Teacher);
				m.HasOne(t => t.Group);
			});


			builder.Entity<Translation>(m => {
				m.ToTable("Translation");
			});

			builder.Entity<TranslationCode>(m => {
				m.ToTable("TranslationCode");
			});

			builder.Entity<Page>(m => {
				m.ToTable("Page");
			});
		}
	}
}
