using TimeTable.Model;
using TimeTable.DAL.UnitOfWork;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace TimeTable.DAL.Repository {
	public interface IRepository<TContext>
		where TContext : DbContext {

		TEntity GetEntity<TEntity>(int id, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseModel;
		EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : BaseModel;
		void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseModel;
		void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseModel;
		bool Delete<TEntity>(TEntity entity) where TEntity : BaseModel;
		bool DeleteById<TEntity>(int id) where TEntity : BaseModel;
		bool DeleteRange<TEntity>(Expression<Func<TEntity, bool>> predicate = null) where TEntity : BaseModel;

		IUnitOfWork<TContext> UnitOfWork { get; }
	}
}
