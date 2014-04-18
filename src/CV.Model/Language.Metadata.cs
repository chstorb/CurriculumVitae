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
        [DisplayName("Person")]
        public int PersonId { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string LanguageName { get; set; }

        [DisplayName("Level")]
        public string Level { get; set; }
    }
}