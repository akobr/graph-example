using System;
using Microsoft.EntityFrameworkCore;

namespace Graph.Model
{
    public interface IGenericDataContext
    {
        Type EntityType { get; }

        string EntityTypeKey { get; }
    }

    public interface IGenericDataContext<TEntity> : IGenericDataContext
        where TEntity : class
    {
        DbSet<TEntity> Entities { get; }

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}