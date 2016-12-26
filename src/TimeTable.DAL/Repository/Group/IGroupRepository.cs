using System.Collections.Generic;
using TimeTable.DAL.DBContext;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {
	public interface IGroupRepository : IRepository<EntityDbContext> {
		GroupItems GetGroupItems(GroupFilter filter);
		ICollection<Group> GetGroups(int? typeId = null);
		GroupDetails GetGroupDetails(int id);
	}
}
