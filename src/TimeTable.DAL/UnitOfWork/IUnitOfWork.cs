using Microsoft.EntityFrameworkCore;
using System;

namespace TimeTable.DAL.UnitOfWork {
	public interface IUnitOfWork<TContext> : IDisposable
		where TContext : DbContext {

		void SaveChanges();
		void ClearChanges();
		TContext DbContext { get; }
	}
}
