using TimeTable.Model;
using TimeTable.DAL.DBContext;

namespace TimeTable.DAL.Repository {

	public interface IPageRepository : IRepository<EntityDbContext> {
		Page GetPage(int id);
	}
}
