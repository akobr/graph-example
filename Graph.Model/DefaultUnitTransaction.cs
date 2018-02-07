using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Graph.Model
{
    public class DefaultUnitTransaction : IUnitTransaction
    {
        private readonly IDbContextTransaction transaction;
        private bool disposed = false;

        public DefaultUnitTransaction(IDataContext dataContext)
        {
            transaction = dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                Rollback();
            }
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                transaction.Dispose();
            }

            disposed = true;
        }
    }
}