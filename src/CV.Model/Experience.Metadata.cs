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
        [DisplayName("Resume")]
        public int ResumeId { get; set; }

        [DisplayName("Employer")]
        public string Employer { get; set; }

        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [DisplayName("Industry")]
        public string Industry { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State/Province")]
        public string StateProvince { get; set; }

        [DisplayName("Country/Region")]
        public string CountryRegion { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> StartDate { get; set; }

        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EndDate { get; set; }

        [DisplayName("Responsibilities")]
        public string Responsibilities { get; set; }

        [DefaultValue(true)]
        [DisplayName("Visible")]
        public bool Visible { get; set; }
    }
}
