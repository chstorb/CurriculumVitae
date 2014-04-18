using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Model
{
    /// <summary>
    /// AddressMetadata class.
    /// </summary>
    public sealed class AddressMetadata
    {
        private AddressMetadata() { }
        [DisplayName("Street")]
        [DataType(DataType.MultilineText)]
        public string Street { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State/Province")]
        public string StateProvince { get; set; }

        [DisplayName("ZIP/Postal Code")]
        public string ZipPostalCode { get; set; }

        [DisplayName("Country/Region")]
        public string CountryRegion { get; set; }
    }
}
