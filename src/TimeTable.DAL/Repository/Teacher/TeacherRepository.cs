using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTable.Common;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {
	public class TeacherRepository : BaseRepository<EntityDbContext>, ITeacherRepository {
		public TeacherRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }

		public bool HasSubject(int teacherId, int subjectId) {
			return UnitOfWork.DbContext.Set<SubjectTeacher>().Any(t => t.TeacherId == teacherId && t.SubjectId == subjectId);
		}

		public TeacherDetails GetTeacherDetails(int id) {
			var entity = GetEntity<Teacher>(id);
			if (entity == null) { 
				return null;
			}
			
			var subjects = GetQuery<SubjectTeacher>().Where(t => t.TeacherId == id)
				.Join(
					GetQuery<Subject>(),
					st => st.SubjectId,
					t => t.Id,
					(st, t) => t.Id
				).ToArray<int>();

			var details = new TeacherDetails {
				Id = entity.Id,
				Name = entity.Name,
				Patronymic = entity.Patronymic,
				Surname = entity.Surname,
				PositionId = entity.PositionId,
				SubjectIds = subjects
			};
			return details;
		}

		public TeacherItems GetTeacherItems(TeacherFilter filter) {
			var items = GetQuery<Teacher>();
			//.Join(UnitOfWork.DbContext.Set<DomainValue>(), t => t.PositionId, dv => dv.Id,
			//	(t, dv) => new { t.Id, t.Name, t.Surname, t.Patronymic, t.PositionId, PositionNameCode = dv.NameCode });

			if (filter.Skip.HasValue) {
				items = items.Skip(filter.Skip.Value);
			}

			if (filter.Take.HasValue) {
				items = items.Skip(filter.Take.Value);
			}

			if (!string.IsNullOrEmpty(filter.Name)) {
				items = items.Where(m => m.Name.Contains(filter.Name));
			}

			return new TeacherItems {
				Items = items.Select(m =>
					new TeacherItem {
						Id = m.Id,
						Name = m.Name,
						Patronymic = m.Patronymic,
						Surname = m.Surname,
						PositionId = m.PositionId
					}
				).ToList()
			};
		}

		public void UpdateSubjects(Teacher teacher, ICollection<int> subjectIds) {
			DeleteRange<SubjectTeacher>(e => e.TeacherId == teacher.Id);
			UnitOfWork.DbContext.SaveChanges();
			foreach (var subjectId in subjectIds) {
				Add(SubjectTeacher.Create(subjectId, teacher.Id));
			}
		}

		public ICollection<KeyValue> GetTeachers(int? subjectId = null) {
			var query = GetQuery<Teacher>()
				.Include(t => t.Subjects)
				.AsQueryable();

			if (subjectId.HasValue) {
				query = query.Where(t => t.Subjects.Any(s => s.TeacherId == subjectId));
			}

			return query.Select(s => new KeyValue {
				Id = s.Id,
				Value = Format.FormattedShortName(s.Surname, s.Name, s.Patronymic)
			}).ToList();
		}
	}
}
