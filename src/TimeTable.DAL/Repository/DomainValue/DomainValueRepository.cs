using System.Linq;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;
using System.Collections.Generic;
using TimeTable.Common.AppConstants;
using Microsoft.EntityFrameworkCore;

namespace TimeTable.DAL.Repository {

	public class DomainValueRepository : BaseRepository<EntityDbContext>, IDomainValueRepository {

		public DomainValueRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }

		public int? GetDomainValueNameCode(int domainValueId) {
			return GetEntity<DomainValue>(domainValueId)?.NameCode;
		}

		public ICollection<DomainValue> GetDomainValuesByType(int domainValueTypeId) {
			return UnitOfWork.DbContext.Set<DomainValue>().Where(d => d.DomainValuedTypeId == domainValueTypeId).ToList();
		}

		public ICollection<DomainValue> GetWorkingDays() {
			return GetQuery<DomainValue>().Where(d => d.Id >= Dom.DomainValue.Monday && d.Id <= Dom.DomainValue.Friday).ToList();
		}

		public bool CheckDomainValueOfType(int domainValueId, int domainValueTypeId) {
			return GetDomainValuesByType(domainValueTypeId).Select(t => t.Id).Contains(domainValueId);
		}

		public ICollection<DomainValue> GetAvailableWeekAlternations(int? dayId = null, int? groupId = null, int? number = null) {
			var query = GetQuery<Class>()
				.Include(c => c.Load)
				.AsQueryable();

			if (groupId.HasValue) {
				query = query.Where(c => c.Load.GroupId == groupId);
			}

			var weekAlternations = GetDomainValuesByType(Dom.DomainValueType.WeeksAlternation);

			var classEntity = query.FirstOrDefault(c => c.DayOfWeekId == dayId && c.Number == number);
			if (classEntity == null) {
				return weekAlternations;
			} else if (classEntity.WeekAlternationId == Dom.DomainValue.First) {
				return weekAlternations.Where(d => d.Id == Dom.DomainValue.Second).ToList();
			} else if (classEntity.WeekAlternationId == Dom.DomainValue.Second) {
				return weekAlternations.Where(d => d.Id == Dom.DomainValue.First).ToList();
			} else {
				return new List<DomainValue>();
			}
		}
	}
}