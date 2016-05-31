using System.Data.Entity;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Bgts.Gps.EntityFramework.Repositories
{
    public abstract class VhasRepositoryBase<TDbContext, TEntity, TPrimaryKey> :
        EfRepositoryBase<TDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        protected VhasRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
