using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TimeTable.DAL.DBContext;

namespace TimeTable.DAL.Migrations.EntityDb
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20161226132401_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("TimeTable.Model.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 32);

                    b.HasKey("Id");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("TimeTable.Model.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayOfWeekId");

                    b.Property<int>("LoadId");

                    b.Property<int>("Number");

                    b.Property<int>("RoomId");

                    b.Property<int>("WeekAlternationId");

                    b.HasKey("Id");

                    b.HasIndex("LoadId");

                    b.HasIndex("RoomId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("TimeTable.Model.DomainValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DomainValuedTypeId");

                    b.Property<int>("NameCode");

                    b.HasKey("Id");

                    b.ToTable("DomainValue");
                });

            modelBuilder.Entity("TimeTable.Model.DomainValueType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DomainValueType");
                });

            modelBuilder.Entity("TimeTable.Model.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 128);

                    b.Property<byte?>("StudentsCount");

                    b.Property<int>("TypeId");

                    b.Property<byte?>("Year");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("TimeTable.Model.GroupRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<int>("ParentGroupId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentGroupId");

                    b.ToTable("GroupRelation");
                });

            modelBuilder.Entity("TimeTable.Model.Load", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<int>("HoursPerWeek");

                    b.Property<int>("SubjectId");

                    b.Property<int>("SubjectTypeId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Load");
                });

            modelBuilder.Entity("TimeTable.Model.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDetailPage");

                    b.Property<int>("TitleCode");

                    b.HasKey("Id");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("TimeTable.Model.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingId");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<byte>("PlacesCount");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("TimeTable.Model.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("TimeTable.Model.SubjectTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SubjectId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("TimeTable.Model.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Patronymic");

                    b.Property<int>("PositionId");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("TimeTable.Model.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LanguageId");

                    b.Property<int>("TranslationCode");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Translation");
                });

            modelBuilder.Entity("TimeTable.Model.TranslationCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TranslationCode");
                });

            modelBuilder.Entity("TimeTable.Model.Class", b =>
                {
                    b.HasOne("TimeTable.Model.Load", "Load")
                        .WithMany()
                        .HasForeignKey("LoadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeTable.Model.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TimeTable.Model.GroupRelation", b =>
                {
                    b.HasOne("TimeTable.Model.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeTable.Model.Group", "ParentGroup")
                        .WithMany()
                        .HasForeignKey("ParentGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TimeTable.Model.Load", b =>
                {
                    b.HasOne("TimeTable.Model.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeTable.Model.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeTable.Model.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TimeTable.Model.Room", b =>
                {
                    b.HasOne("TimeTable.Model.Building", "Building")
                        .WithMany("Rooms")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TimeTable.Model.SubjectTeacher", b =>
                {
                    b.HasOne("TimeTable.Model.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TimeTable.Model.Teacher", "Teacher")
                        .WithMany("Subjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
