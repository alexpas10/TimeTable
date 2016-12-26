using TimeTable.DAL.DBContext;
using TimeTable.Model;
using System.Collections.Generic;

namespace TimeTable.DAL.Repository {
	public interface IDomainValueRepository : IRepository<EntityDbContext> {
		ICollection<DomainValue> GetDomainValuesByType(int domainValueTypeId);
		ICollection<DomainValue> GetWorkingDays();
		int? GetDomainValueNameCode(int domainValueId);
		bool CheckDomainValueOfType(int domainValueId, int domainValueTypeId);
		ICollection<DomainValue> GetAvailableWeekAlternations(int? dayId = null, int? groupId = null, int? number = null);
	}
}
