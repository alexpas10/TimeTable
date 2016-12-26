using System.Collections.Generic;
using TimeTable.DAL.DBContext;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {
	public interface IClassRepository : IRepository<EntityDbContext> {
		ClassItems GetClassItems(ClassFilter filter);
		ClassDetails GetClassDetails(int id);
	}
}
