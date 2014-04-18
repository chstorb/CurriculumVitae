using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    /// <summary>
    /// ContactdDetail class.
    /// </summary>
    [MetadataTypeAttribute(typeof(ContactDetailMetadata))]
    public abstract partial class ContactDetail
    {
        public abstract IEnumerable<string> ValidUsageValues { get; }

        /// <summary>
        /// Contact Detail ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Person Id (foreign key)
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Person navigation property
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Usage
        /// </summary>
        public string Usage { get; set; }
    }
}
