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
        [Display(Name = "Person", ResourceType = typeof(Resources.Resources))]
        public int PersonId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "FieldRequired")]
        public string Title { get; set; }
        
        [DefaultValue(true)]
        [Display(Name = "Visible", ResourceType = typeof(Resources.Resources))]
        public bool Visible { get; set; }

        [Display(Name = "WorkAuthorisationFor", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(NullDisplayText = "Arbeitserlaubnis für jeden Arbeitgeber")]
        public string WorkAuthorisationFor { get; set; }

        [Display(Name = "CurrentCareerLevel", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(NullDisplayText="Berufserfahren")]
        public string CurrentCareerLevel { get; set; }

        [Display(Name = "CurrentEducationLevel", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(NullDisplayText="FH/Bachelor oder gleichwertig")]
        public string CurrentEducationLevel { get; set; }

        [Display(Name = "SalaryFrom", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Currency)]
        [Column(TypeName="money")]
        public decimal SalaryFrom { get; set; }

        [Display(Name = "SalaryTo", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal SalaryTo { get; set; }

        [Display(Name = "PreferredCountry", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(NullDisplayText="Germany")]
        public string PreferredCountry { get; set; }

        [Display(Name = "PreferredLocation", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(NullDisplayText = "North Rhine-Westphalia")]
        public string PreferredLocation { get; set; }

        [Display(Name = "DesiredJobType", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(NullDisplayText = "Permanent")]
        public string DesiredJobType { get; set; }

        [Display(Name = "DesiredJobStatus", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(NullDisplayText = "Full-time")]
        public string DesiredJobStatus { get; set; }

        [Display(Name = "TravelDaysPerMonth", ResourceType = typeof(Resources.Resources))]
        [DisplayFormat(NullDisplayText = "0")]
        public int TravelDaysPerMonth { get; set; }

        [Display(Name = "AvailabilityDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> AvailabilityDate { get; set; }

        [Display(Name = "Notes", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}
