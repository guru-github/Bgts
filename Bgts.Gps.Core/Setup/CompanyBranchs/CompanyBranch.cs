using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Abp.Collections.Extensions;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;
using Bgts.Gps.Setup.Cities;
using Bgts.Gps.Setup.Companies;

namespace Bgts.Gps.Setup.CompanyBranchs
{
    [Table("CompanyBranch")]
    public class CompanyBranch : FullAuditedAndTenantEntity<int>
    {
        public const int BranchNameMaxLength = 32;
        public const int Address1MaxLength = 64;
        public const int Address2MaxLength = 64;
        
        public const int ZipcodeMaxLength = 10;
        public const int FaxMaxLength = 16;
        public const int ContactNameMaxLength = 32;
        public const int ContactPhoneMaxLength = 16;
        public const int EmergNameMaxLength = 32;
        public const int EmergPhoneMaxLength = 32;
        public const int MaxCodeLength = 128;

        /// <summary>
        /// Maximum depth of an branch hierarchy.
        /// </summary>
        public const int MaxDepth = 16;

        /// <summary>
        /// Length of a code unit between dots.
        /// </summary>
        public const int CodeUnitLength = 5;

        ///// <summary>
        ///// Maximum length of the <see cref="Code"/> property.
        ///// </summary>
        //public const int MaxCodeLength = MaxDepth * (CodeUnitLength + 1) - 1;

        [ForeignKey("ParentId")]
        public virtual CompanyBranch Parent { get; set; }

        public int? ParentId { get; set; }

        [StringLength(MaxCodeLength)]
        public string Code { get; set; }

        [Required]
        [StringLength(BranchNameMaxLength)]
        public string BranchName { get; set; }

        [Required]
        [StringLength(Address1MaxLength)]
        public string Address1 { get; set; }

        [StringLength(Address2MaxLength)]
        public string Address2 { get; set; }

        public int? CityId { get; set; }

        [StringLength(ZipcodeMaxLength)]
        public string Zipcode { get; set; }

        [StringLength(FaxMaxLength)]
        public string Fax { get; set; }

        [Required]
        [StringLength(ContactNameMaxLength)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(ContactPhoneMaxLength)]
        public string ContactPhone { get; set; }

        [StringLength(EmergNameMaxLength)]
        public string EmergName { get; set; }

        [StringLength(EmergPhoneMaxLength)]
        public string EmergPhone { get; set; }

        public int? CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        /// <summary>
        /// Children of this branch.
        /// </summary>
        public virtual ICollection<CompanyBranch> Children { get; set; }

        /// <summary>
        /// Creates code for given numbers.
        /// Example: if numbers are 4,2 then returns "00004.00002";
        /// </summary>
        /// <param name="numbers">Numbers</param>
        public static string CreateCode(params int[] numbers)
        {
            if (numbers.IsNullOrEmpty())
            {
                return null;
            }

            return numbers.Select(number => number.ToString(new string('0', CodeUnitLength))).JoinAsString(".");
        }

        /// <summary>
        /// Appends a child code to a parent code. 
        /// Example: if parentCode = "00001", childCode = "00042" then returns "00001.00042".
        /// </summary>
        /// <param name="parentCode">Parent code. Can be null or empty if parent is a root.</param>
        /// <param name="childCode">Child code.</param>
        public static string AppendCode(string parentCode, string childCode)
        {
            if (childCode.IsNullOrEmpty())
            {
                throw new ArgumentNullException("childCode", "childCode can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return childCode;
            }

            return parentCode + "." + childCode;
        }

        /// <summary>
        /// Gets relative code to the parent.
        /// Example: if code = "00019.00055.00001" and parentCode = "00019" then returns "00055.00001".
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="parentCode">The parent code.</param>
        public static string GetRelativeCode(string code, string parentCode)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException("code", "code can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return code;
            }

            if (code.Length == parentCode.Length)
            {
                return null;
            }

            return code.Substring(parentCode.Length + 1);
        }

        /// <summary>
        /// Calculates next code for given code.
        /// Example: if code = "00019.00055.00001" returns "00019.00055.00002".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string CalculateNextCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException("code", "code can not be null or empty.");
            }

            var parentCode = GetParentCode(code);
            var lastUnitCode = GetLastUnitCode(code);

            return AppendCode(parentCode, CreateCode(Convert.ToInt32(lastUnitCode) + 1));
        }

        /// <summary>
        /// Gets the last unit code.
        /// Example: if code = "00019.00055.00001" returns "00001".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetLastUnitCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException("code", "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            return splittedCode[splittedCode.Length - 1];
        }

        /// <summary>
        /// Gets parent code.
        /// Example: if code = "00019.00055.00001" returns "00019.00055".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetParentCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException("code", "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            if (splittedCode.Length == 1)
            {
                return null;
            }

            return splittedCode.Take(splittedCode.Length - 1).JoinAsString(".");
        }
    }
}
