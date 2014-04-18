using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    /// <summary>
    /// Experience class.
    /// </summary>
    [MetadataTypeAttribute(typeof(ExperienceMetadata))]
    public partial class Experience
    {
        /// <summary>
        /// Experience ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Resume ID (foreign key)
        /// </summary>
        public int ResumeId { get; set; }

        /// <summary>
        /// Employer
        /// </summary>
        public string Employer { get; set; }

        /// <summary>
        /// Job Title
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Industry
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State / Province
        /// </summary>
        public string StateProvince { get; set; }

        /// <summary>
        /// Country / Region
        /// </summary>
        public string CountryRegion { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// Responsibilites
        /// </summary>
        public string Responsibilities { get; set; }

        /// <summary>
        /// Experience visible in resumee (true / false)
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Resume navigation property
        /// </summary>
        public virtual Resume Resume { get; set; }

        /// <summary>
        /// SkillMatrix navigation property
        /// </summary>
        public virtual List<SkillMatrix> SkillMatrix { get; set; }        
    }
}