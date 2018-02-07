using System;

namespace Graph.Model
{
    public interface IUnitOfWork : IDisposable
    {
        IDataContext DataContext { get; }

        IUnitTransaction Transaction { get; }

        IGenericDataContext<TEntry> GetGenericRepository<TEntry>()
            where TEntry : class;

        void Save();
    }
}