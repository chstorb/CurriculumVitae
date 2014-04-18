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
    /// ContactDetailMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "ContactDetail")]
    public sealed class ContactDetailMetadata
    {
        private ContactDetailMetadata() {}

        //[Key]
        //public int ContactDetailId { get; set; }

        [ForeignKey("Person")]
        [DisplayName("Person")]
        public int PersonId { get; set; }
        
        [DisplayName("Art")]
        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string Usage { get; set; }
    }
}