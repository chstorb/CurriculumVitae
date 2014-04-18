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

        [DisplayName("Title")]
        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string Title { get; set; }

        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Website")]
        public string WebAddress { get; set; }
    }
}
