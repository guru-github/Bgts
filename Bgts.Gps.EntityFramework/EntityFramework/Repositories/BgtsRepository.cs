﻿using Abp.Domain.Entities;
using Abp.EntityFramework;

namespace Bgts.Gps.EntityFramework.Repositories
{
    public class BgtsRepository<TEntity, TPrimaryKey> :
       BgtsRepositoryBase<BgtsDbContext, TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
    {
        public BgtsRepository(IDbContextProvider<BgtsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
