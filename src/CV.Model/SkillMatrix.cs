using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    /// <summary>
    /// SkillMatrix class.
    /// </summary>
    [MetadataTypeAttribute(typeof(SkillMatrixMetadata))]
    public partial class SkillMatrix
    {
        /// <summary>
        /// SkillMatrix ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Experience ID (foreign key)
        /// </summary>
        public int ExperienceId { get; set; }

        /// <summary>
        /// Skill ID (foreign key)
        /// </summary>
        public int SkillId { get; set; }
        
        /// <summary>
        /// Skill level
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public Nullable<DateTime> StartDate { get; set; }

        /// <summary>
        /// End Date
        /// </summary>
        public Nullable<DateTime> EndDate { get; set; }

        /// <summary>
        /// Experience navigation property
        /// </summary>
        public virtual Experience Experience { get; set; }

        /// <summary>
        /// Skill navigation property
        /// </summary>
        public virtual Skill Skill { get; set; }
    }
}
