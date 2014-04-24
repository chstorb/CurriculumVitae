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
    /// AttachmentMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "Attachment")]
    public sealed class AttachmentMetadata
    {
        private AttachmentMetadata() {}

        [ForeignKey("Person")]
        [Display(Name = "Person", ResourceType = typeof(Resources.Resources))]
        public int PersonId { get; set; }

        [Display(Name = "Title", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
            ErrorMessageResourceName = "FieldRequired")]
        public string Title { get; set; }

        [Display(Name = "Type", ResourceType = typeof(Resources.Resources))]
        public string AttachmentType { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime AttachmentDate { get; set; }

        [Display(Name = "FileType", ResourceType = typeof(Resources.Resources))]
        public string FileType { get; set; }

        [Display(Name = "FilePath", ResourceType = typeof(Resources.Resources))]
        public string FilePath { get; set; }

        [Display(Name = "Summary", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
    }
}