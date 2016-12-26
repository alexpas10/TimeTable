using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {

	public class GroupRepository : BaseRepository<EntityDbContext>, IGroupRepository {

		public GroupRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }

		public GroupDetails GetGroupDetails(int id) {
			var entity = GetEntity<Group>(id);
			if (entity == null) {
				return null;
			} else {
				ICollection<KeyValue> subGroups = new List<KeyValue>();
				foreach(var rel in GetQuery<GroupRelation>().Where(r => r.ParentGroupId == entity.Id)) {
					subGroups.Add(new KeyValue {
						Id = rel.GroupId,
						Value = GetEntity<Group>(rel.GroupId).Name
					});
				}
				ICollection<KeyValue> parentGroups = new List<KeyValue>();
				foreach(var rel in GetQuery<GroupRelation>().Where(r => r.GroupId == entity.Id)) {
					parentGroups.Add(new KeyValue {
						Id = rel.ParentGroupId,
						Value = GetEntity<Group>(rel.ParentGroupId).Name
					});
				}
				
				return new GroupDetails {
					Id = entity.Id,
					Name = entity.Name,
					StudentsCount = entity.StudentsCount,
					Year = entity.Year,
					SubGroups = subGroups,
					ParentGroups = parentGroups
				};
			}
		}

		public GroupItems GetGroupItems(GroupFilter filter) {
			var items = GetQuery<Group>();

			if (filter.Skip.HasValue) {
				items = items.Skip(filter.Skip.Value);
			}

			if (filter.Take.HasValue) {
				items = items.Skip(filter.Take.Value);
			}

			if (!string.IsNullOrEmpty(filter.Name)) {
				items = items.Where(m => m.Name.Contains(filter.Name));
			}

			if (filter.StudentsCountFrom.HasValue) {
				items = items.Where(m => m.StudentsCount >= filter.StudentsCountFrom);
			}

			if (filter.StudentsCountTo.HasValue) {
				items = items.Where(m => m.StudentsCount <= filter.StudentsCountTo);
			}

			if (filter.Year.HasValue) {
				items = items.Where(m => m.Year == filter.Year);
			}

			return new GroupItems {
				Items = items.Select(m =>
					new GroupItem {
						Id = m.Id,
						Name = m.Name,
						Year = m.Year,
						StudentsCount = m.StudentsCount
					}
				).ToList()
			};
		}

		public ICollection<Group> GetGroups(int? typeId = null) {
			var query = GetQuery<Group>();
			if (typeId.HasValue) {
				query = query.Where(g => g.TypeId == typeId);
			}
			return query.ToList();
		}
	}
}