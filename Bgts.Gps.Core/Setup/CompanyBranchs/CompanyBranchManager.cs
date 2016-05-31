using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Threading;
using Abp.UI;

namespace Bgts.Gps.Setup.CompanyBranchs
{
    public class CompanyBranchManager : VhasDomainServiceBase
    {
        protected IRepository<CompanyBranch> BranchRepository { get; private set; }

        public CompanyBranchManager(IRepository<CompanyBranch> branchRepository)
        {
            BranchRepository = branchRepository;
        }

        [UnitOfWork]
        public virtual async Task CreateAsync(CompanyBranch branch)
        {
            branch.Code = await GetNextChildCodeAsync(branch.ParentId);
            await ValidateBranchAsync(branch);
            await BranchRepository.InsertAsync(branch);
        }

        public virtual async Task UpdateAsync(CompanyBranch branch)
        {
            await ValidateBranchAsync(branch);
            await BranchRepository.UpdateAsync(branch);
        }

        public virtual async Task<string> GetNextChildCodeAsync(int? parentId)
        {
            var lastChild = await GetLastChildOrNullAsync(parentId);
            if (lastChild == null)
            {
                var parentCode = parentId != null ? await GetCodeAsync(parentId.Value) : null;
                return CompanyBranch.AppendCode(parentCode, CompanyBranch.CreateCode(1));
            }

            return CompanyBranch.CalculateNextCode(lastChild.Code);
        }

        public virtual async Task<CompanyBranch> GetLastChildOrNullAsync(int? parentId)
        {
            var children = await BranchRepository.GetAllListAsync(ou => ou.ParentId == parentId);
            return children.OrderBy(c => c.Code).LastOrDefault();
        }

        public virtual string GetCode(int id)
        {
            //TODO: Move to an extension class
            return AsyncHelper.RunSync(() => GetCodeAsync(id));
        }

        public virtual async Task<string> GetCodeAsync(int id)
        {
            return (await BranchRepository.GetAsync(id)).Code;
        }

        [UnitOfWork]
        public virtual async Task DeleteAsync(int id)
        {
            var children = await FindChildrenAsync(id, true);

            foreach (var child in children)
            {
                await BranchRepository.DeleteAsync(child);
            }

            await BranchRepository.DeleteAsync(id);
        }

        [UnitOfWork]
        public virtual async Task MoveAsync(int id, int? parentId)
        {
            var branch = await BranchRepository.GetAsync(id);
            if (branch.ParentId == parentId)
            {
                return;
            }

            //Should find children before Code change
            var children = await FindChildrenAsync(id, true);

            //Store old code of OU
            var oldCode = branch.Code;

            //Move OU
            branch.Code = await GetNextChildCodeAsync(parentId);
            branch.ParentId = parentId;

            await ValidateBranchAsync(branch);

            //Update Children Codes
            foreach (var child in children)
            {
                child.Code = CompanyBranch.AppendCode(branch.Code, CompanyBranch.GetRelativeCode(child.Code, oldCode));
            }
        }

        public async Task<List<CompanyBranch>> FindChildrenAsync(int? parentId, bool recursive = false)
        {
            if (recursive)
            {
                if (!parentId.HasValue)
                {
                    return await BranchRepository.GetAllListAsync();
                }

                var code = await GetCodeAsync(parentId.Value);
                return await BranchRepository.GetAllListAsync(ou => ou.Code.StartsWith(code) && ou.Id != parentId.Value);
            }
            return await BranchRepository.GetAllListAsync(ou => ou.ParentId == parentId);
        }

        protected virtual async Task ValidateBranchAsync(CompanyBranch branch)
        {
            var siblings = (await FindChildrenAsync(branch.ParentId))
                .Where(x => x.Id != branch.Id)
                .ToList();

            if (siblings.Any(x => x.BranchName == branch.BranchName))
            {
                throw new UserFriendlyException(L("BranchDuplicateBranchNameWarning", branch.BranchName));
            }
        }
    }
}
