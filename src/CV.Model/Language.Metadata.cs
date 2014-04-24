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
    /// LanguageMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "Language")]
    public sealed class LanguageMetadata
    {
        private LanguageMetadata() { }

        [ForeignKey("Person")]
        [Display(Name = "Person", ResourceType = typeof(Resources.Resources))]
        public int PersonId { get; set; }

        [Display(Name = "Language", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "FieldRequired")]
        public string LanguageName { get; set; }

        [Display(Name = "Level", ResourceType = typeof(Resources.Resources))]
        public string Level { get; set; }
    }
}