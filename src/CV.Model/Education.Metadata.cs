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
    /// EducationMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "Education")]
    public sealed class EducationMetadata
    {
        private EducationMetadata() { }

        [ForeignKey("Person")]
        [DisplayName("Person")]
        public int PersonId { get; set; }

        [DisplayName("School/Institution")]
        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string SchoolInstitution { get; set; }

        [DisplayName("Degree")]
        public string Degree { get; set; }

        [DisplayName("Date from")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [DisplayName("Date to")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        [DisplayName("Concentrations")]
        public string Concentrations { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State/Province")]
        public string StateProvince { get; set; }
        
        [DisplayName("Country/Region")]
        public string CountryRegion { get; set; }
        
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}