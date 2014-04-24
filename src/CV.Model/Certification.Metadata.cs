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
        [Display(Name = "Person", ResourceType = typeof(Resources.Resources))]
        public int PersonId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resources))]
        public string Title { get; set; }

        [Display(Name = "Institution", ResourceType = typeof(Resources.Resources))]
        public string InstitutionName { get; set; }

        [Display(Name = "DateOfReceipt", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DateOfReceipt { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Resources))]
        public string City { get; set; }

        [Display(Name = "StateProvince", ResourceType = typeof(Resources.Resources))]
        public string StateProvince { get; set; }

        [Display(Name = "CountryRegion", ResourceType = typeof(Resources.Resources))]
        public string CountryRegion { get; set; }

        [Display(Name = "Summary", ResourceType = typeof(Resources.Resources))]
        public string Summary { get; set; }
    }
}