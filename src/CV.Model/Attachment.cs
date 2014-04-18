using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{    
    /// <summary>
    /// Attachment class.
    /// </summary>
    [MetadataTypeAttribute(typeof(AttachmentMetadata))]
    public partial class Attachment
    {
        /// <summary>
        /// Attachment ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Person Id (foreign key)
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        private static string[] validAttachmentTypeValues = new string[] { "Image", "Reference", "Certificate of Learning" };

        public IEnumerable<string> ValidAttachmentTypeValues
        {
            get { return validAttachmentTypeValues; }
        }

        /// <summary>
        /// Attachment Type
        /// </summary>
        public string AttachmentType { get; set; }

        /// <summary>
        /// Attachment Date
        /// </summary>
        public Nullable<DateTime> AttachmentDate { get; set; }

        private static string[] validFileTypeValues = new string[] { "JPEG" };

        public IEnumerable<string> ValidFileTypeValues
        {
            get { return validFileTypeValues; }
        }

        /// <summary>
        /// File Type
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// File Path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Summary
        /// </summary>
        public string Summary { get; set; }
                
        /// <summary>
        /// Person navigation property
        /// </summary>
        public virtual Person Person { get; set; }
    }
}