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
    /// ExperienceMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "Experience")]
    public sealed class ExperienceMetadata
    {
        private ExperienceMetadata() { }

        [ForeignKey("Resume")]
        [Display(Name = "Resume", ResourceType = typeof(Resources.Resources))]
        public int ResumeId { get; set; }

        [Display(Name = "Employer", ResourceType = typeof(Resources.Resources))]
        public string Employer { get; set; }

        [Display(Name = "JobTitle", ResourceType = typeof(Resources.Resources))]
        public string JobTitle { get; set; }

        [Display(Name = "Industry", ResourceType = typeof(Resources.Resources))]
        public string Industry { get; set; }

        [DisplayName("City")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        public string City { get; set; }

        [Display(Name = "StateProvince", ResourceType = typeof(Resources.Resources))]
        public string StateProvince { get; set; }

        [Display(Name = "CountryRegion", ResourceType = typeof(Resources.Resources))]
        public string CountryRegion { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "StartDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> StartDate { get; set; }

        [Display(Name = "EndDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EndDate { get; set; }

        [Display(Name = "Responsibilities", ResourceType = typeof(Resources.Resources))]
        public string Responsibilities { get; set; }

        [DefaultValue(true)]
        [Display(Name = "Visible", ResourceType = typeof(Resources.Resources))]
        public bool Visible { get; set; }
    }
}
