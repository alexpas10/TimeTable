using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeTable.Common;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {

	public class ClassRepository : BaseRepository<EntityDbContext>, IClassRepository {

		public ClassRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }


		public ClassDetails GetClassDetails(int id) {
			var entity = GetEntity<Class>(id);
			if (entity == null) {
				return null;
			} else {
				return new ClassDetails {
					Id = entity.Id
				};
			}
		}

		public ClassItems GetClassItems(ClassFilter filter) {
			var query = GetQuery<Class>()
				.Include(c => c.Load)
				.Include(c => c.Room)
				.AsQueryable();

			if (filter.DayOfWeekId.HasValue) {
				query = query.Where(c => c.DayOfWeekId == filter.DayOfWeekId);
			}

			if (filter.GroupId.HasValue) {
				query = query.Where(c => c.Load.GroupId == filter.GroupId);
			}

			if (filter.RoomId.HasValue) {
				query = query.Where(c => c.RoomId == filter.RoomId);
			}

			if (filter.SubjectId.HasValue) {
				query = query.Where(c => c.Load.SubjectId == filter.SubjectId);
			}

			if (filter.TeacherId.HasValue) {
				query = query.Where(c => c.Load.TeacherId == filter.TeacherId);
			}

			var resultQuery = query.Join(GetQuery<Teacher>(),
				c => c.Load.TeacherId,
				t => t.Id,
				(c, t) => new { Class = c, TeacherName = Format.FormattedShortName(t.Surname, t.Name, t.Patronymic) }
			).Join(GetQuery<Subject>(),
				x => x.Class.Load.SubjectId,
				s => s.Id,
				(x, s) => new { Class = x.Class, TeacherName = x.TeacherName, SubjectName = s.ShortName ?? s.Name }
			).Join(GetQuery<Group>(),
				x => x.Class.Load.GroupId,
				g => g.Id,
				(x, g) => new { Class = x.Class, TeacherName = x.TeacherName, SubjectName = x.SubjectName, GroupName = g.Name }
			);

			return new ClassItems {
				Items = resultQuery.Select(m =>
					new ClassItem {
						Id = m.Class.Id,
						DayOfWeekId = m.Class.DayOfWeekId,
						RoomId = m.Class.RoomId,
						LoadId = m.Class.LoadId,
						WeekAlternationId = m.Class.WeekAlternationId,
						Number = m.Class.Number,
						RoomName = m.Class.Room.Name,
						GroupName = m.GroupName,
						SubjectName = m.SubjectName,
						TeacherName = m.TeacherName,
						GroupId = m.Class.Load.GroupId
					}).ToList()
			};
		}

	}
}