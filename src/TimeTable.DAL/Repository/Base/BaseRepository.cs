using TimeTable.Common;
using TimeTable.Model;
using TimeTable.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace TimeTable.DAL.Repository {

	public class BaseRepository<TContext> : IRepository<TContext> where TContext : DbContext {

		public IUnitOfWork<TContext> UnitOfWork { get; }

		public BaseRepository(IUnitOfWork<TContext> unitOfWork) {
			if (unitOfWork == null)
				throw new ArgumentNullException(nameof(unitOfWork));

			UnitOfWork = unitOfWork;
		}

		public TEntity GetEntity<TEntity>(int id, params Expression<Func<TEntity, object>>[] includes)
			where TEntity : BaseModel {

			var entity = GetQuery<TEntity>().Where(t => t.Id == id);

			if (!includes.IsNullOrEmpty())
				entity = includes.Aggregate(entity, (query, include) => query.Include(include));

			return entity.FirstOrDefault();
		}

		public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseModel {
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			return UnitOfWork.DbContext.Set<TEntity>().Add(entity);
		}

		public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseModel {
			if (entities.IsNullOrEmpty())
				throw new ArgumentNullException(nameof(entities));

			UnitOfWork.DbContext.Set<TEntity>().AddRange(entities);
		}

		public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseModel {
			if (entity == null) {
				throw new ArgumentNullException(nameof(entity));
			}

			if (GetQuery<TEntity>().Any(e => e.Id == entity.Id)) {
				UnitOfWork.DbContext.Set<TEntity>().Attach(entity);
				UnitOfWork.DbContext.Entry(entity).State = EntityState.Modified;
			} else {
				UnitOfWork.DbContext.Set<TEntity>().Add(entity);
			}
		}

		public bool Delete<TEntity>(TEntity entity)
			where TEntity : BaseModel {
			if (entity == null) {
				return false;
			}
			UnitOfWork.DbContext.Entry(entity).State = EntityState.Deleted;
			return true;
		}

		public bool DeleteRange<TEntity>(Expression<Func<TEntity, bool>> predicate = null)
			where TEntity : BaseModel {
			if (predicate != null) {
				var entities = GetQuery<TEntity>(predicate);
				foreach (var entity in entities) {
					Delete(entity);
				}
				return true;
			}
			return false;
		}

		public bool DeleteById<TEntity>(int id)
			where TEntity : BaseModel {
			var entity = UnitOfWork.DbContext.Set<TEntity>().FirstOrDefault(e => e.Id == id);
			return Delete(entity);
		}

		protected IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : class {
			var result = UnitOfWork.DbContext.Set<TEntity>();
			if (predicate != null) {
				return result?.Where(predicate);
			 }
			return result;
		}
	}
}
