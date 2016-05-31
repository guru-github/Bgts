using System.Data.Entity;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Bgts.Auth.EntityFramework.Repositories
{
    public abstract class AuthRepositoryBase<TDbContext, TEntity, TPrimaryKey> :
        EfRepositoryBase<TDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        protected AuthRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
