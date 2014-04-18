using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Model
{
    /// <summary>
    /// Email class.
    /// </summary>
    [MetadataTypeAttribute(typeof(EmailMetadata))]
    public partial class Email : ContactDetail
    {
        private static string[] validUsageValues = new string[] { "Business", "Home" };

        public override IEnumerable<string> ValidUsageValues
        {
            get { return validUsageValues; }
        }

        /// <summary>
        /// E-Mail Address
        /// </summary>
        public string EMailAddress { get; set; }
    }
}
