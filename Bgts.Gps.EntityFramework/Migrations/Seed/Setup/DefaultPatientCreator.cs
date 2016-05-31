using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.Patients;
using Bgts.Gps.EntityFramework;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultPatientCreator : DefaultBaseCreator<Patient>
    {
        public DefaultPatientCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
        }

        public void Create()
        {
            CreatePatients();
        }

        private void CreatePatients()
        {
            //branch id
            /*
                 
             B1
                B11
                    B111
                    B112
                B12
             B2
                B21
             */

            var b1 = GetCompanyBranch(DefaultCfg.CompanyBranch_B1).Id;
            var b11 = GetCompanyBranch(DefaultCfg.CompanyBranch_B11).Id;
            var b111 = GetCompanyBranch(DefaultCfg.CompanyBranch_B111).Id;
            var b112 = GetCompanyBranch(DefaultCfg.CompanyBranch_B112).Id;
            var b12 = GetCompanyBranch(DefaultCfg.CompanyBranch_B12).Id;
            var b2 = GetCompanyBranch(DefaultCfg.CompanyBranch_B2).Id;
            var b21 = GetCompanyBranch(DefaultCfg.CompanyBranch_B21).Id;

            var city = GetCity();

            CreatePatient(b1, "Lucy", "Hu", city.Id, "510000", "Address1");
            CreatePatient(b11, "Lei", "Li", city.Id, "510000", "Address2");
            CreatePatient(b11, "Tonny", "Song", city.Id, "510000", "Address of Tonny Song");
            CreatePatient(b11, "Helen", "Wen", city.Id, "510000", "Adress of Helen Wen");
            CreatePatient(b12, "Frank", "Lin", city.Id, "510000", "Address3");
            CreatePatient(b111, "Perry", "Yu", city.Id, "510000", "Address4");
            CreatePatient(b111, "Carl", "Dai", city.Id, "510000", "Address5");
            CreatePatient(b112, "Arvin", "Dai", city.Id, "510000", "Address6");
            CreatePatient(b2, "Ming", "Xie", city.Id, "510000", "Address7");
            CreatePatient(b21, "Down", "Son", city.Id, "510000", "Address8");
        }

        private Patient CreatePatient(int branchId, string firstName, string lastName, int cityId, string zipcode,
            string address)
        {
            var patient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                TenantId = TenantId,
                CompanyBranchId = branchId,
                Address = address,
                CityId = cityId,
                Zipcode = zipcode
            };

            if (VisitContext.Patients.Any(x => x.TenantId == TenantId && x.FirstName == firstName && x.LastName == lastName))
            {
                return patient;
            }

            VisitContext.Patients.Add(patient);
            VisitContext.SaveChanges();

            return patient;
        }
    }
}