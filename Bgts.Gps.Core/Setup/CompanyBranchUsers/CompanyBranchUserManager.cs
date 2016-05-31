
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Bgts.Auth.Authorization.Users;
using Bgts.Gps.Setup.CompanyBranchs;

namespace Bgts.Gps.Setup.CompanyBranchUsers
{
    public class CompanyBranchUserManager : VhasDomainServiceBase
    {
        private readonly IRepository<CompanyBranchUser, long> _userBranchRepository;

        private readonly IRepository<CompanyBranch> _branchRepository;

        private readonly UserManager _userManager;

        private readonly UserStore _userStore;

        public CompanyBranchUserManager(
            UserManager userManager,
            UserStore userStore,
            IRepository<CompanyBranchUser, long> userBranchRepository,
            IRepository<CompanyBranch> branchRepository)
        {
            _userManager = userManager;
            _userStore = userStore;
            _userBranchRepository = userBranchRepository;
            _branchRepository = branchRepository;
        }

        public virtual async Task<bool> IsInCompanyBranchAsync(long userId, int branchId)
        {
            var user = await _userManager.GetUserByIdAsync(userId);
            var branch = await _branchRepository.FirstOrDefaultAsync(x => x.Id == branchId);

            return await IsInCompanyBranchAsync(user, branch);
        }

        public virtual async Task<bool> IsInCompanyBranchAsync(User user, CompanyBranch branch)
        {
            var count = await _userBranchRepository.CountAsync(ub => ub.UserId == user.Id && ub.CompanyBranchId == branch.Id);
            return count > 0;
        }

        public virtual async Task AddToCompanyBranchAsync(long userId, int branchId)
        {
            await AddToCompanyBranchAsync(
                await _userManager.GetUserByIdAsync(userId),
                await _branchRepository.GetAsync(branchId)
                );
        }

        public virtual async Task AddToCompanyBranchAsync(User user, CompanyBranch branch)
        {
            var currentBranchs = await GetCompanyBranchsAsync(user.Id);

            if (currentBranchs.Any(b => b.Id == branch.Id))
            {
                return;
            }

            await _userBranchRepository.InsertAsync(new CompanyBranchUser(user.TenantId, user.Id, branch.Id));
        }

        public virtual async Task RemoveFromCompanyBranchAsync(long userId, int branchId)
        {
            await RemoveFromCompanyBranchAsync(
                await _userManager.GetUserByIdAsync(userId),
                await _branchRepository.GetAsync(branchId)
                );
        }

        public virtual async Task RemoveFromCompanyBranchAsync(User user, CompanyBranch branch)
        {
            await _userBranchRepository.DeleteAsync(ub => ub.UserId == user.Id && ub.CompanyBranchId == branch.Id);
        }

        [UnitOfWork]
        public virtual Task<List<CompanyBranch>> GetCompanyBranchsAsync(long userId)
        {
            var query = from ub in _userBranchRepository.GetAll()
                        join b in _branchRepository.GetAll() on ub.CompanyBranchId equals b.Id
                        where ub.UserId == userId
                        select b;

            return Task.FromResult(query.ToList());
        }

        public virtual async Task SetCompanyBranchsAsync(long userId, params int[] branchIds)
        {
            await SetCompanyBranchsAsync(
                await _userManager.GetUserByIdAsync(userId),
                branchIds
                );
        }

        public virtual async Task SetCompanyBranchsAsync(User user, params int[] branchIds)
        {
            if (branchIds == null)
            {
                branchIds = new int[0];
            }

            var currentBranchs = await GetCompanyBranchsAsync(user.Id);

            //Remove from removed branchs
            foreach (var currentbranch in currentBranchs)
            {
                if (!branchIds.Contains(currentbranch.Id))
                {
                    await RemoveFromCompanyBranchAsync(user, currentbranch);
                }
            }

            //Add to added OUs
            foreach (var branchId in branchIds)
            {
                if (currentBranchs.All(b => b.Id != branchId))
                {
                    await AddToCompanyBranchAsync(
                        user,
                        await _branchRepository.GetAsync(branchId)
                        );
                }
            }
        }

        //[UnitOfWork]
        //public virtual Task<List<User>> GetUsersInBranch(BranchEntity branch, bool includeChildren = false)
        //{
        //    if (!includeChildren)
        //    {
        //        var query = from ub in _userBranchRepository.GetAll()
        //                    join user in _userStore.Users on ub.UserId equals user.Id
        //                    where ub.BranchId == branch.Id
        //                    select user;

        //        return Task.FromResult(query.ToList());
        //    }
        //    else
        //    {
        //        var query = from ub in _userBranchRepository.GetAll()
        //                    join user in _userStore.Users on ub.UserId equals user.Id
        //                    join b in _branchRepository.GetAll() on ub.BranchId equals b.Id
        //                    where b.Code.StartsWith(branch.Code)
        //                    select user;

        //        return Task.FromResult(query.ToList());
        //    }
        //}
    }
}
