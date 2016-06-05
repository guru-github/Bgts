using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Bcs.Gps.EntityFramework.Repositories
{
    public abstract class GpsRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<GpsDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected GpsRepositoryBase(IDbContextProvider<GpsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class GpsRepositoryBase<TEntity> : GpsRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected GpsRepositoryBase(IDbContextProvider<GpsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
