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
        [Display(Name = "Person", ResourceType = typeof(Resources.Resources))]
        public int PersonId { get; set; }
        
        [Display(Name = "Usage", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "FieldRequired")]
        public string Usage { get; set; }
    }
}