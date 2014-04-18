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
    /// Address class.
    /// </summary>
    [MetadataTypeAttribute(typeof(AddressMetadata))]
    public partial class Address : ContactDetail
    {
        private static string[] validUsageValues = new string[] { "Business", "Home", "Mailing" };

        public override IEnumerable<string> ValidUsageValues
        {
            get { return validUsageValues; }
        }
        
        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }       

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State / Province
        /// </summary>
        public string StateProvince { get; set; }

        /// <summary>
        /// Zip / Postal Code
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Country / Region
        /// </summary>
        public string CountryRegion { get; set; }
    }
}
