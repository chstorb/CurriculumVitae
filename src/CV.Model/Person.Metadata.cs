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
    /// PersonMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "Person")]
    public sealed class PersonMetadata
    {        
        private PersonMetadata() {}
        
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "The '{0}' field is required.")]
        public string LastName { get; set; }

        [DisplayName("Birth Name")]
        public string BirthName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Martial Status")]
        public string MartialStatus { get; set; }

        [DisplayName("Number of children")]
        [DefaultValue(0)]
        public int NumberOfChildren { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [DisplayName("Place of Birth")]
        public string PlaceOfBirth { get; set; }

        [DisplayName("Nationality")]
        public string Nationality { get; set; }

        [DisplayName("Mother")]
        public int MotherId { get; set; }

        [DisplayName("Father")]
        public int FatherId { get; set; }

        [DisplayName("Notes")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [DisplayName("Category")]
        public string Category { get; set; }

        [Display(Name = "Name")]
        public string FullName;
    }
}