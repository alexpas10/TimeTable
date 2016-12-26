using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {

	public class PageRepository : BaseRepository<EntityDbContext>, IPageRepository {
		public PageRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }

		public Page GetPage(int id) {
			return GetEntity<Page>(id);
		}
	}
}
