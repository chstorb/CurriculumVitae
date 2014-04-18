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
    /// ResumeMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "Resume")]
    public sealed class ResumeMetadata
    {
        private ResumeMetadata() { }

        [ForeignKey("Person")]
        [DisplayName("Person")]
        public int PersonId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string Title { get; set; }
        
        [DefaultValue(true)]
        [DisplayName("Visible")]
        public bool Visible { get; set; }

        [DisplayName("Work authorisation for")]
        [DisplayFormat(NullDisplayText = "Arbeitserlaubnis für jeden Arbeitgeber")]
        public string WorkAuthorisationFor { get; set; }

        [DisplayName("Current Career level")]
        [DisplayFormat(NullDisplayText="Berufserfahren")]
        public string CurrentCareerLevel { get; set; }

        [DisplayName("Current Education level")]
        [DisplayFormat(NullDisplayText="FH/Bachelor oder gleichwertig")]
        public string CurrentEducationLevel { get; set; }

        [DisplayName("Salary from")]
        [DataType(DataType.Currency)]
        [Column(TypeName="money")]
        public decimal SalaryFrom { get; set; }

        [DisplayName("Salary to")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SalaryTo { get; set; }

        [DisplayName("Peferred country")]
        [DisplayFormat(NullDisplayText="Germany")]
        public string PreferredCountry { get; set; }

        [DisplayName("Preferred location")]
        [DisplayFormat(NullDisplayText = "North Rhine-Westphalia")]
        public string PreferredLocation { get; set; }

        [DisplayName("Desired job type")]
        [DisplayFormat(NullDisplayText = "Permanent")]
        public string DesiredJobType { get; set; }

        [DisplayName("Desired job status")]
        [DisplayFormat(NullDisplayText = "Full-time")]
        public string DesiredJobStatus { get; set; }

        [DisplayName("Travel days per month")]
        [DisplayFormat(NullDisplayText = "0")]
        public int TravelDaysPerMonth { get; set; }

        [DisplayName("Availability date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> AvailabilityDate { get; set; }

        [DisplayName("Notes")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}
