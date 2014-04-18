using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    /// <summary>
    /// Resume class.
    /// </summary>
    [MetadataTypeAttribute(typeof(ResumeMetadata))]
    public partial class Resume
    {
        /// <summary>
        /// Resume ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Person ID (foreign key)
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Resume Name / Title
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Resume visible (true/false)
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Work authorisation for
        /// </summary>
        public string WorkAuthorisationFor { get; set; }

        /// <summary>
        /// Current career level
        /// </summary>
        public string CurrentCareerLevel { get; set; }

        /// <summary>
        /// Current education level
        /// </summary>
        public string CurrentEducationLevel { get; set; }

        /// <summary>
        /// Salary From
        /// </summary>
        public Nullable<decimal> SalaryFrom { get; set; }

        /// <summary>
        /// Salary To
        /// </summary>
        public Nullable<decimal> SalaryTo { get; set; }

        /// <summary>
        /// Preferred country
        /// </summary>
        public string PreferredCountry { get; set; }

        /// <summary>
        /// Preferred location
        /// </summary>
        public string PreferredLocation { get; set; }

        /// <summary>
        /// Desired job type
        /// </summary>
        public string DesiredJobType { get; set; }

        /// <summary>
        /// Desired job status
        /// </summary>
        public string DesiredJobStatus { get; set; }

        /// <summary>
        /// Travel days per month
        /// </summary>
        public Nullable<int> TravelDaysPerMonth { get; set; }
                             
        /// <summary>
        /// Availability date
        /// </summary>
        public Nullable<DateTime> AvailabilityDate { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Person navigation property
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Experiences navigation property
        /// </summary>
        public virtual List<Experience> Experiences { get; set; }
    }
}
