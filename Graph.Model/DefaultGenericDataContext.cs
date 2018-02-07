using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Graph.Model
{
    public class DefaultGenericDataContext<TEntity> : IGenericDataContext<TEntity>
        where TEntity : class
    {
        private readonly IDataContext context;

        public DefaultGenericDataContext(IDataContext dataContext)
        {
            context = dataContext;
            Entities = dataContext.Set<TEntity>();
        }

        public DbSet<TEntity> Entities { get; }

        public Type EntityType => typeof(TEntity);

        public string EntityTypeKey => EntityType.FullName;

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }

            Entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                Entities.Attach(entity);

                EntityEntry<TEntity> entry = context.Entry(entity);

                if (entry.State == EntityState.Unchanged)
                {
                    entry.State = EntityState.Modified;
                }
            }
        }
    }
}