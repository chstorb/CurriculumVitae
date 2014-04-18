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
        [DisplayName("Person")]
        public int PersonId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string Title { get; set; }

        [DisplayName("Type")]
        public string AttachmentType { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime AttachmentDate { get; set; }

        [DisplayName("File Type")]
        public string FileType { get; set; }

        [DisplayName("File Path")]
        public string FilePath { get; set; }

        [DisplayName("Summary")]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
    }
}