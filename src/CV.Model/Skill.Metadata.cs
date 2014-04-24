using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Model
{
    using CV.Common;

    /// <summary>
    /// SkillMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "Skill")]
    public class SkillMetadata
    {
        private SkillMetadata() { }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "FieldRequired")]
        public string Title { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Website", ResourceType = typeof(Resources.Resources))]
        public string WebAddress { get; set; }
    }
}
