using System.Collections.Generic;
using TimeTable.DAL.DBContext;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {
	public interface ILoadRepository : IRepository<EntityDbContext> {
		LoadItems GetLoadItems(LoadFilter filter);
		ICollection<LoadItem> GetLoads(int? teacherId = null, int? subjectId = null, int? groupId = null);
		ICollection<LoadSelectItem> GetAvailableLoads(int? dayId = null, int? groupId = null, int? number = null);
		LoadDetails GetLoadDetails(int id);
	}
}
