
using Abp.Domain.Entities;
using Abp.EntityFramework;
namespace Bgts.Auth.EntityFramework.Repositories
{
    public class AuthRepository<TEntity, TPrimaryKey> :
        AuthRepositoryBase<AuthDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public AuthRepository(IDbContextProvider<AuthDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
