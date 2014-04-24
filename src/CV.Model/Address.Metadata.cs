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
        [Display(Name = "Street", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Street { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Resources))]
        public string City { get; set; }

        [Display(Name = "StateProvince", ResourceType = typeof(Resources.Resources))]
        public string StateProvince { get; set; }

        [Display(Name = "ZipPostalCode", ResourceType = typeof(Resources.Resources))]
        public string ZipPostalCode { get; set; }

        [Display(Name = "CountryRegion", ResourceType = typeof(Resources.Resources))]
        public string CountryRegion { get; set; }
    }
}
