using System.Collections.Generic;
using System.Linq;
using Bgts.Auth.EntityFramework;
using Bgts.Gps.Setup.Skills;
using Bgts.Gps.EntityFramework;
using Bgts.Gps.EnumTypes;

namespace Bgts.Gps.Migrations.Seed.Setup
{
    public class DefaultSkillCreator : DefaultBaseCreator<Skill>
    {
        private readonly List<Skill> skills;

        public DefaultSkillCreator(AuthDbContext authContext,
            VhasDbContext context)
            : base(authContext, context)
        {
            skills = new List<Skill>
            {
                new Skill
                {
                    SkillType = (int) SkillTypes.LicensesAndPermits,
                    Description = "LicensesAndPermits",
                    TenantId = TenantId
                },
                new Skill
                {
                    SkillType = (int) SkillTypes.Qualifications,
                    Description = "Qualifications",
                    TenantId = TenantId
                },new Skill
                {
                    SkillType = (int) SkillTypes.Training,
                    Description = "Training",
                    TenantId = TenantId
                }
            };
        }

        public void Create()
        {
            CreateSkills();
        }

        private void CreateSkills()
        {
            foreach (var skill in skills)
            {
                AddIfNotExists(skill);
            }
        }

        private void AddIfNotExists(Skill skill)
        {
            if (VisitContext.Skills.Any(x => x.TenantId == skill.TenantId &&
                x.Description == skill.Description))
            {
                return;
            }

            VisitContext.Skills.Add(skill);
            VisitContext.SaveChanges();
        }
    }
}