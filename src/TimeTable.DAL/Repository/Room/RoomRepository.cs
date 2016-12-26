using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TimeTable.DAL.DBContext;
using TimeTable.DAL.UnitOfWork;
using TimeTable.Model;

namespace TimeTable.DAL.Repository {

	public class RoomRepository : BaseRepository<EntityDbContext>, IRoomRepository {

		public RoomRepository(IUnitOfWork<EntityDbContext> unitOfWork)
			: base(unitOfWork) { }

		public ICollection<SelectItem> GetAvailableRooms(int? dayId = null, int? number = null) {
			var query = GetQuery<Class>()
				.Include(c => c.Room)
				.ToList();

			var unavailableRooms = query
				.Where(c => c.DayOfWeekId == dayId && c.Number == number).Select(c => c.Room).ToList();

			return GetQuery<Room>().Select(r => new SelectItem {
				Id = r.Id,
				Value = r.Name,
				Disabled = unavailableRooms.Any(x => x.Id == r.Id)
			}).Distinct().ToList();
		}

		public RoomDetails GetRoomDetails(int id) {
			var entity = GetEntity<Room>(id);
			return (entity == null) ? null : new RoomDetails {
				Id = entity.Id,
				Name = entity.Name,
				PlacesCount = entity.PlacesCount,
				TypeId = entity.TypeId,
				TypeNameCode = UnitOfWork.DbContext.Set<DomainValue>().FirstOrDefault(m => m.Id == entity.TypeId)?.NameCode,
				BuildingId = entity.BuildingId,
				BuildingName = UnitOfWork.DbContext.Set<Building>().FirstOrDefault(m => m.Id == entity.BuildingId)?.Name
			};
		}

		public RoomItems GetRoomItemsWithSQL(RoomFilter filter) {
			string whereClause = string.Empty;

			if (!string.IsNullOrEmpty(filter.Name)) {
				whereClause += $"[R].[Name] LIKE '%{filter.Name}%' ";
			}

			if (filter.PlacesCountFrom.HasValue) {
				if (!string.IsNullOrEmpty(whereClause)) {
					whereClause += " AND ";
				}
				whereClause += $"[R].[PlacesCount] >= {filter.PlacesCountFrom} ";
			}

			if (filter.PlacesCountTo.HasValue) {
				if (!string.IsNullOrEmpty(whereClause)) {
					whereClause += " AND ";
				}
				whereClause += $"[R].[PlacesCount] <= {filter.PlacesCountTo} ";
			}

			if (filter.BuildingId.HasValue) {
				if (!string.IsNullOrEmpty(whereClause)) {
					whereClause += " AND ";
				}
				whereClause += $"[R].[BuildingId] = {filter.BuildingId} ";
			}

			if (filter.TypeId.HasValue) {
				if (!string.IsNullOrEmpty(whereClause)) {
					whereClause += " AND ";
				}
				whereClause += $"[R].[TypeId] = {filter.TypeId} ";
			}

			if (!string.IsNullOrEmpty(whereClause)) {
				whereClause = "WHERE " + whereClause;
			}

			var items1 = UnitOfWork.DbContext.Set<Room>().FromSql(
				$@"
					SELECT *
					FROM Room [R]
						INNER JOIN [Building] [B] on [R].[BuildingId] = [B].[Id] "
					+ whereClause +
					$"LIMIT {filter.Take} OFFSET {filter.Skip}")
			.Join(UnitOfWork.DbContext.Set<DomainValue>(), r => r.TypeId, dv => dv.Id,
				(r, dv) => new { r.Id, r.Name, r.PlacesCount, BuildingName = r.Building.Name, TypeNameCode = dv.NameCode }); ;

			return new RoomItems {
				Items = items1.Select(m =>
					new RoomItem {
						Id = m.Id,
						Name = m.Name,
						PlacesCount = m.PlacesCount,
						TypeNameCode = m.TypeNameCode,
						BuildingName = m.BuildingName
					}
				).ToList()
			};
		}

		public RoomItems GetRoomItems(RoomFilter filter) {
			var items = GetQuery<Room>()
				.Join(UnitOfWork.DbContext.Set<Building>(), r => r.BuildingId, b => b.Id,
					(r, b) => new { r.BuildingId, r.Id, r.Name, r.PlacesCount, r.TypeId, BuildingName = b.Name })
				.GroupJoin(
					UnitOfWork.DbContext.Set<DomainValue>(),
					r => r.TypeId,
					dv => dv.Id,
					(r, dv) => new { Room = r, DomainValues = dv.DefaultIfEmpty() }).ToList()
				.SelectMany(
					x => x.DomainValues,
					(x, domainValue) => new { x.Room.Id, x.Room.Name, x.Room.PlacesCount, x.Room.BuildingId, x.Room.BuildingName, x.Room.TypeId, domainValue?.NameCode }
			);

			if (filter.Skip.HasValue) {
				items = items.Skip(filter.Skip.Value);
			}

			if (filter.Take.HasValue) {
				items = items.Skip(filter.Take.Value);
			}

			if (!string.IsNullOrEmpty(filter.Name)) {
				items = items.Where(m => m.Name.Contains(filter.Name));
			}

			if (filter.PlacesCountFrom.HasValue) {
				items.Where(m => m.PlacesCount >= filter.PlacesCountFrom);
			}

			if (filter.PlacesCountTo.HasValue) {
				items.Where(m => m.PlacesCount <= filter.PlacesCountTo);
			}

			if (filter.BuildingId.HasValue) {
				items.Where(m => m.BuildingId == filter.BuildingId);
			}

			if (filter.TypeId.HasValue) {
				items.Where(m => m.TypeId == filter.TypeId);
			}

			return new RoomItems {
				Items = items.Select(m =>
					new RoomItem {
						Id = m.Id,
						Name = m.Name,
						PlacesCount = m.PlacesCount,
						TypeNameCode = m.NameCode,
						BuildingName = m.BuildingName
					}
				).ToList()
			};
		}
	}
}