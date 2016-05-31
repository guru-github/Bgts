using Abp.Domain.Entities;
using Abp.EntityFramework;

namespace Bgts.Gps.EntityFramework.Repositories
{
    public class VhasRepository<TEntity, TPrimaryKey> :
       VhasRepositoryBase<VhasDbContext, TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
    {
        public VhasRepository(IDbContextProvider<VhasDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
