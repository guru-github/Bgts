using System.Collections.Generic;
using System.Linq;
using Abp.Localization;
using Bgts.Auth.EntityFramework;

namespace Bgts.Auth.Migrations.Seed
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguages { get; private set; }

        private readonly AuthDbContext _context;

        static DefaultLanguagesCreator()
        {
            InitialLanguages = new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "en", "English", "flag gb"),
                new ApplicationLanguage(null, "zh-CN", "简体中文", "flag cn")
            };
        }

        public DefaultLanguagesCreator(AuthDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            //if (_context.Languages.Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            //{
            //    return;
            //}

            //_context.Languages.Add(language);

            //_context.SaveChanges();
        }
    }
}