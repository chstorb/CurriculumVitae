using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    using CV.Common;

    /// <summary>
    /// CertificationMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "Certification")]
    public sealed class CertificationMetadata
    {
        private CertificationMetadata() { }

        [ForeignKey("Person")]
        [DisplayName("Person")]
        public int PersonId { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Institution")]
        public string InstitutionName { get; set; }

        [DisplayName("Date of Receipt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateOfReceipt { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State/Province")]
        public string StateProvince { get; set; }

        [DisplayName("Country/Region")]
        public string CountryRegion { get; set; }

        [DisplayName("Summary")]
        public string Summary { get; set; }
    }
}