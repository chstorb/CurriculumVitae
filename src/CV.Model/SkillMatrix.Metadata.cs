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
    /// SkillMatrixMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "SkillMatrix")]
    public sealed class SkillMatrixMetadata
    {
        private SkillMatrixMetadata() { }

        [ForeignKey("Skill")]
        [Display(Name = "Skill", ResourceType = typeof(Resources.Resources))]
        public int SkillId { get; set; }

        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }
            
        [Display(Name = "StartDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> StartDate { get; set; }

        [Display(Name = "EndDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> EndDate { get; set; }
    }
}
