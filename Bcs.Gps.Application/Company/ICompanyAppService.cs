using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Bcs.Gps.Company.Dto;
using System.Threading.Tasks;

namespace Bcs.Gps.Company
{
    public interface ICompanyAppService : IApplicationService
    {
        Task CreateOrUpdateCompanyDetail(CreateOrUpdateCompanyDetailInput input);

        Task DeleteCompanyDetail(IdInput<int> input);

        Task<GetCompanyDetailForEditOutput> GetCompanyDetailById(IdInput<int> input);

        Task<ListResultOutput<CompanyDetailListDto>> GetCompanyDetails(IdInput<int> input);
    }
}
