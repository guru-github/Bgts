using Bgts.Auth.EntityFramework;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.Migrations.Seed.Authorization;
using Bgts.Gps.Migrations.Seed.Setup;
using Bgts.Gps.Migrations.Seed.Maintain;
using EntityFramework.DynamicFilters;
using Bgts.Gps.Migrations.Seed.Scheduling;

namespace Bgts.Gps.Migrations.Seed
{
    public class VhasDbInit
    {
        private readonly AuthDbContext _authContext;
        private readonly VhasDbContext _vhasContext;

        public VhasDbInit(AuthDbContext authContext, VhasDbContext vhasContext)
        {
            _authContext = authContext;
            _vhasContext = vhasContext;
        }

        public void Create()
        {
            _authContext.DisableAllFilters();
            _vhasContext.DisableAllFilters();

            //if you want init permission and feature data before you start using this programe
            //but I think we should mannually set it.
            new DefaultPermissionAndFeatureCreator(_authContext).Create();

            new DefaultTimezoneCreator(_authContext, _vhasContext).Create();
            new DefaultCityCreator(_authContext, _vhasContext).Create();
            new DefaultAreaCreator(_authContext, _vhasContext).Create();
            new DefaultSecurityRequiredLocationCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyBranchCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyBranchUserCreator(_authContext, _vhasContext).Create();

           

            new DefaultSkillCreator(_authContext, _vhasContext).Create();
            new DefaultPatientCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyContactCreator(_authContext, _vhasContext).Create();

            new DefaultClientCreator(_authContext, _vhasContext).Create();
            new DefaultClientBranchCreator(_authContext, _vhasContext).Create();
            new DefaultClientContactCreator(_authContext, _vhasContext).Create();
            new DefaultClientEmployeeCreator(_authContext, _vhasContext).Create();

            new DefaultClientEmployeePictureCreator(_authContext, _vhasContext).Create();
            new DefaultInactiveReasonCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyEmployeeCreator(_authContext, _vhasContext).Create();

            new DefaultCompanyEmployeeBanCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyEmployeeAbsenceCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyEmployeeDaysNotAvailableCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyEmployeeEmailCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyEmployeeSkillCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyEmployeeTelephoneCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyEmployeeTypeCreator(_authContext, _vhasContext).Create();
            
            new DefaultCompanyEmployeeWorkAtCityCreator(_authContext, _vhasContext).Create();
            new DefaultCompanyEmployeePictureCreator(_authContext, _vhasContext).Create();

            new DefaultScheduleCreator(_authContext, _vhasContext).Create();
            new DefaultJobMasterCreator(_authContext, _vhasContext).Create();
            new DefaultJobDetailCreator(_authContext, _vhasContext).Create();
            

            _vhasContext.SaveChanges();
            _authContext.SaveChanges();
        }
    }
}
