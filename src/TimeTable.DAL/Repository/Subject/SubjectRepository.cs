using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {

	public class SubjectRepository : BaseRepository<EntityDbContext>, ISubjectRepository {

		public SubjectRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }

		public SubjectDetails GetSubjectDetails(int id) {
			var entity = GetEntity<Subject>(id);
			if (entity == null) {
				return null;
			}
			var teachers = GetQuery<SubjectTeacher>().Where(t => t.SubjectId == id)
				.Join(
					GetQuery<Teacher>(),
					st => st.TeacherId,
					t => t.Id,
					(st, t) => t.Id
				).ToArray();
			return new SubjectDetails {
				Id = entity.Id,
				Name = entity.Name,
				ShortName = entity.ShortName,
				TeacherIds = teachers
			};
		}

		public SubjectItems GetSubjectItems(SubjectFilter filter) {
			var items = GetQuery<Subject>();

			if (filter.Skip.HasValue) {
				items = items.Skip(filter.Skip.Value);
			}

			if (filter.Take.HasValue) {
				items = items.Skip(filter.Take.Value);
			}

			if (!string.IsNullOrEmpty(filter.Name)) {
				items = items.Where(m => m.Name.Contains(filter.Name));
			}

			return new SubjectItems {
				Items = items.Select(m =>
					new SubjectItem {
						Id = m.Id,
						Name = m.Name,
						ShortName = m.ShortName,
					}
				).ToList()
			};
		}

		public void UpdateTeachers(Subject subject, ICollection<int> teacherIds) {
			DeleteRange<SubjectTeacher>(e => e.SubjectId == subject.Id);
			UnitOfWork.DbContext.SaveChanges();
			foreach (var teacherId in teacherIds) {
				Add(SubjectTeacher.Create(subject.Id, teacherId));
			}
		}

		public ICollection<KeyValue> GetSubjects(int? teacherId = null) {
			var query = GetQuery<Subject>()
				.Include(t => t.Teachers)
				.AsQueryable();

			if (teacherId.HasValue) {
				query = query.Where(t => t.Teachers.Any(s => s.TeacherId == teacherId));
			}

			return query.Select(s => new KeyValue {
				Id = s.Id,
				Value = s.Name
			}).ToList();
		}
	}
}