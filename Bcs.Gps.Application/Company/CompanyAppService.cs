using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Bcs.Gps.Company.Dto;
using Abp.Domain.Repositories;
using Abp.AutoMapper;


namespace Bcs.Gps.Company
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly IRepository<Companies.Company, int> _repository;

        public CompanyAppService(IRepository<Companies.Company, int> repository)
        {
            _repository = repository;
        }
       
        public async Task CreateOrUpdateCompanyDetail(CreateOrUpdateCompanyDetailInput input)
        {
            if (input.Id.HasValue)
            {
                await Update(input);
            }
            else
            {
                await Create(input);
            }
        }
        
        public async Task DeleteCompanyDetail(IdInput<int> input)
        {
            await _repository.DeleteAsync(input.Id);
        }
        
        public async Task<GetCompanyDetailForEditOutput> GetCompanyDetailById(IdInput<int> input)
        {
            var entity = await _repository.FirstOrDefaultAsync(input.Id);
            return entity.MapTo<GetCompanyDetailForEditOutput>();
        }
        
        public async Task<ListResultOutput<CompanyDetailListDto>> GetCompanyDetails(IdInput<int> input)
        {
            var list = await _repository.GetAllListAsync(x => x.Id == input.Id);

            return new ListResultOutput<CompanyDetailListDto>(list.MapTo<List<CompanyDetailListDto>>());            
        }
        protected async Task Create(CreateOrUpdateCompanyDetailInput input)
        {
            var entity = input.MapTo<Companies.Company>();
            await _repository.InsertAsync(entity);
        }

        protected async Task Update(CreateOrUpdateCompanyDetailInput input)
        {
            var entity = await _repository.FirstOrDefaultAsync(Convert.ToInt32(input.Id.Value));
            if (entity == null)
            {
                throw new Exception("Not found record ");
            }

            input.MapTo(entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
