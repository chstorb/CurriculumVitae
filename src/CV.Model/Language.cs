using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    /// <summary>
    /// Language class.
    /// </summary>
    [MetadataTypeAttribute(typeof(LanguageMetadata))]
    public partial class Language
    {
        /// <summary>
        /// Language ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Person ID (foreign key)
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Language name
        /// </summary>
        public string LanguageName { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// Person navigation property
        /// </summary>
        public virtual Person Person { get; set; }
    }
}