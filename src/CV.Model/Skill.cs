using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Model
{
    /// <summary>
    /// Skill class.
    /// </summary>
    [MetadataTypeAttribute(typeof(SkillMetadata))]
    public partial class Skill
    {
        /// <summary>
        /// Skill ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Skill title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Skill description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Webaddress
        /// </summary>
        public string WebAddress { get; set; }
    }
}
