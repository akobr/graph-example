using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Graph.Model
{
    public class DefaultUnitOfWork : IUnitOfWork
    {
        private readonly IDataContext context;
        private readonly IDictionary<string, IGenericDataContext> repositories;
        private IUnitTransaction transaction;
        private bool disposed = false;

        public DefaultUnitOfWork(IDataContext dataContext)
        {
            context = dataContext;
            repositories = new Dictionary<string, IGenericDataContext>();
        }

        public IDataContext DataContext => context;

        public IUnitTransaction Transaction
            => transaction ?? (transaction = new DefaultUnitTransaction(context));

        public IGenericDataContext<TEntry> GetGenericRepository<TEntry>()
            where TEntry : class
        {
            Type entryType = typeof (TEntry);
            string repoKey = entryType.FullName;

            if (!repositories.ContainsKey(repoKey))
            {
                repositories.Add(repoKey, new DefaultGenericDataContext<TEntry>(context));
            }

            return (IGenericDataContext<TEntry>) repositories[repoKey];
        }

        public void Save()
        {
            context.SaveChanges();
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
                transaction?.Dispose();
                transaction = null;

                context.Dispose();
            }

            disposed = true;
        }

        private static string CreateMessageFromDbUpdateException(DbUpdateException exception)
        {
            StringBuilder stb = new StringBuilder();

            foreach (var eve in exception.Entries)
            {
                stb.Append($"Entity of type '{eve.Entity.GetType().Name}' in state '{eve.State}' has been involved in the error.");
            }

            return stb.ToString();
        }
    }
}