using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTable.Common;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;
using System;

namespace TimeTable.DAL.Repository {

	public class LoadRepository : BaseRepository<EntityDbContext>, ILoadRepository {

		public LoadRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }

		public ICollection<LoadSelectItem> GetAvailableLoads(int? dayId = null, int? groupId = null, int? number = null) {
			var query = GetQuery<Load>()
				.Include(l => l.Subject)
				.Include(l => l.Teacher)
				.Include(l => l.Group).AsQueryable();
			if (groupId.HasValue) {
				query = query.Where(l => l.GroupId == groupId).ToList();
			}

			var unavailableLoads = query.Join(GetQuery<Class>().Include(c => c.Load),
				l => l.TeacherId,
				c => c.Load.TeacherId,
				(l, c) => new { c.DayOfWeekId, c.Number, Load = l }
			).Where(x => x.DayOfWeekId == dayId && x.Number == number)
			.Select(x => x.Load).ToList();

			return query.Select(l => new LoadSelectItem {
				Id = l.Id,
				SubjectId = l.SubjectId,
				SubjectName = l.Subject.ShortName ?? l.Subject.Name,
				SubjectTypeId = l.SubjectTypeId,
				TeacherId = l.TeacherId,
				TeacherName = Format.FormattedShortName(l.Teacher.Surname, l.Teacher.Name, l.Teacher.Patronymic),
				Disabled = unavailableLoads.Any(x => x.Id == l.Id)
			}).ToList();
		}

		public LoadDetails GetLoadDetails(int id) {
			var entity = GetEntity<Load>(id);
			if (entity == null) {
				return null;
			} else {
				return new LoadDetails {
					Id = entity.Id,
					GroupId = entity.GroupId,
					GroupName = entity.Group.Name,
					SubjectId = entity.SubjectId,
					SubjectName = entity.Subject.Name,
					TeacherId = entity.TeacherId,
					TeacherName = Format.FormattedFullName(entity.Teacher.Surname, entity.Teacher.Name, entity.Teacher.Patronymic),
				};
			}
		}

		public LoadItems GetLoadItems(LoadFilter filter) {
			var items = GetQuery<Load>();

			if (filter.Skip.HasValue) {
				items = items.Skip(filter.Skip.Value);
			}

			if (filter.Take.HasValue) {
				items = items.Skip(filter.Take.Value);
			}

			return new LoadItems {
				Items = items.Select(m =>
					new LoadItem {
						Id = m.Id,
						GroupId = m.GroupId,
						GroupName = m.Group.Name,
						SubjectId = m.SubjectId,
						SubjectName = m.Subject.Name,
						TeacherId = m.TeacherId,
						TeacherName = Format.FormattedFullName(m.Teacher.Surname, m.Teacher.Name, m.Teacher.Patronymic),
					}).ToList()
			};
		}

		public ICollection<LoadItem> GetLoads(int? teacherId = null, int? subjectId = null, int? groupId = null) {
			var query = GetQuery<Load>()
				.Include(l => l.Subject)
				.Include(l => l.Teacher)
				.Include(l => l.Group).AsQueryable();
			if (teacherId.HasValue) {
				query = query.Where(l => l.TeacherId == teacherId);
			}
			if (subjectId.HasValue) {
				query = query.Where(l => l.SubjectId == subjectId);
			}
			if (groupId.HasValue) {
				query = query.Where(l => l.GroupId == groupId);
			}
			return query.Select(m =>
				new LoadItem {
					Id = m.Id, 
					GroupId = m.GroupId,
					GroupName = m.Group.Name,
					SubjectId = m.SubjectId,
					SubjectName = m.Subject.Name,
					SubjectTypeId = m.SubjectTypeId,
					TeacherId = m.TeacherId,
					TeacherName = Format.FormattedFullName(m.Teacher.Surname, m.Teacher.Name, m.Teacher.Patronymic),
				}).ToList();
		}
	}
}