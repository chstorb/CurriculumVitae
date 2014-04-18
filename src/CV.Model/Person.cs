using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    /// <summary>
    /// Person class.
    /// </summary>
    [MetadataTypeAttribute(typeof(PersonMetadata))]
    public partial class Person
    {
        /// <summary>
        /// Person ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Birth Name
        /// </summary>
        public string BirthName { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Martial Status
        /// </summary>
        public string MartialStatus { get; set; }

        /// <summary>
        /// Number of children
        /// </summary>
        public Nullable<int> NumberOfChildren { get; set; }
        
        /// <summary>
        /// Birth Date
        /// </summary>
        public Nullable<DateTime> BirthDate { get; set; }

        /// <summary>
        /// Place Of Birth
        /// </summary>
        public string PlaceOfBirth { get; set; }

        /// <summary>
        /// Nationality
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// Mother (Person) ID 
        /// </summary>
        public Nullable<int> MotherId { get; set; }

        /// <summary>
        /// Father (Person) Id 
        /// </summary>
        public Nullable<int> FatherId { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }

        public string FullName
        {
            get
            {
                return LastName + (String.IsNullOrEmpty(FirstName) ? String.Empty : ", " + FirstName);
            }
        }

        /// <summary>
        /// Languages navigation property
        /// </summary>
        public virtual List<Language> Languages { get; set; }

        /// <summary>
        /// Education navigation property
        /// </summary>
        public virtual List<Education> Education { get; set; }

        /// <summary>
        /// Certifications navigation property
        /// </summary>
        public virtual List<Certification> Certifications { get; set; }

        /// <summary>
        /// Contact details navigation property
        /// </summary>
        public virtual List<ContactDetail> ContactDetails { get; set; }

        /// <summary>
        /// Attachments navigation property
        /// </summary>
        public virtual List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Resumes navigation property
        /// </summary>
        public virtual List<Resume> Resumes { get; set; }
    }
}