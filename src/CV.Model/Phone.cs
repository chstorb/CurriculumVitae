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
    /// Phone class.
    /// </summary>
    [MetadataTypeAttribute(typeof(PhoneMetadata))]
    public partial class Phone : ContactDetail
    {
        private static string[] validUsageValues = new string[] { "Business", "Home", "Mobile" };

        public override IEnumerable<string> ValidUsageValues
        {
            get { return validUsageValues; }
        }

        /// <summary>
        /// Phone number
        /// </summary>
        public string Number { get; set; }
    }
}
