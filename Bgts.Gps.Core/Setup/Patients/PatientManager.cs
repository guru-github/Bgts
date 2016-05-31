using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Bgts.Gps.Setup.CompanyBranchs;
using Bgts.Gps.Setup.CompanyBranchUsers;

namespace Bgts.Gps.Setup.Patients
{
    public class PatientManager : VhasDomainServiceBase
    {
        private readonly IRepository<Patient, long> _patientRepository;
        private readonly IRepository<CompanyBranch> _branchRepository;
        private readonly CompanyBranchUserManager _companyBranchUserMananger;

        public PatientManager(
            IRepository<Patient, long> patientRepository,
            IRepository<CompanyBranch> branchRepository,
            CompanyBranchUserManager companyBranchUserMananger
            )
        {
            _patientRepository = patientRepository;
            _branchRepository = branchRepository;
            _companyBranchUserMananger = companyBranchUserMananger;
        }

        public async Task<List<Patient>> GetPatientsInBranchAsync(int companyBranchId)
        {
            return await _patientRepository.GetAllListAsync(x => x.CompanyBranchId == companyBranchId);
        }

        [UnitOfWork]
        public virtual async Task<List<Patient>> GetPatientsInBranchIncludingChildrenAsync(int companyBranchId)
        {
            var code = (await _branchRepository.GetAsync(companyBranchId)).Code;

            var query =
                from patient in _patientRepository.GetAll()
                join branch in _branchRepository.GetAll()
                on patient.CompanyBranchId equals branch.Id
                where branch.Code.StartsWith(code)
                select patient;

            return await query.ToListAsync();
        }

        [UnitOfWork]
        public async Task<List<Patient>> GetPatientsForUserAsync(long userId)
        {
            var branchs = await _companyBranchUserMananger.GetCompanyBranchsAsync(userId);
            var branchIds = branchs.Select(b => b.Id);

            return await _patientRepository.GetAllListAsync(p => p.CompanyBranchId.HasValue && branchIds.Contains(p.CompanyBranchId.Value));
        }

        [UnitOfWork]
        public virtual async Task<List<Patient>> GetPatientsForUserIncludingChildBranchsAsync(long userId)
        {
            var branchs = await _companyBranchUserMananger.GetCompanyBranchsAsync(userId);
            var branchCodes = branchs.Select(x => x.Code);

            var query =
                from patient in _patientRepository.GetAll()
                join branch in _branchRepository.GetAll()
                on patient.CompanyBranchId equals branch.Id
                where branchCodes.Any(code => branch.Code.StartsWith(code))
                select patient;

            return await query.ToListAsync();
        }

    }
}
