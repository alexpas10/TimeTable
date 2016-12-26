using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace TimeTable.DAL.UnitOfWork {
	public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext {

		private bool _disposed;

		public TContext DbContext { get; }

		public UnitOfWork(TContext dbContext) {
			DbContext = dbContext;
		}

		public void SaveChanges() {
			DbContext.SaveChanges();
		}

		public void ClearChanges() {
			foreach (EntityEntry entry in DbContext.ChangeTracker.Entries()) {
				if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted) {
					entry.State = EntityState.Unchanged;
				} else if (entry.State == EntityState.Added) {
					entry.State = EntityState.Detached;
				}
			}
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (!_disposed) {
				if (disposing) {
					DbContext?.Dispose();
				}
			}
			_disposed = true;
		}
	}
}
