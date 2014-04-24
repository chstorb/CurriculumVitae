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
        [Display(Name = "Person", ResourceType = typeof(Resources.Resources))]
        public int PersonId { get; set; }

        [Display(Name = "SchoolInstitution", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "FieldRequired")]
        public string SchoolInstitution { get; set; }

        [Display(Name = "Degree", ResourceType = typeof(Resources.Resources))]
        public string Degree { get; set; }

        [Display(Name = "DateFrom", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [Display(Name = "DateTo", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        [Display(Name = "Concentrations", ResourceType = typeof(Resources.Resources))]
        public string Concentrations { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Resources))]
        public string City { get; set; }

        [Display(Name = "StateProvince", ResourceType = typeof(Resources.Resources))]
        public string StateProvince { get; set; }
        
        [Display(Name = "CountryRegion", ResourceType = typeof(Resources.Resources))]
        public string CountryRegion { get; set; }
        
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}