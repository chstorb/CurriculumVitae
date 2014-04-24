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
        
        [Display(Name="LastName", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), 
            ErrorMessageResourceName = "FieldRequired")]
        public string LastName { get; set; }

        [Display(Name = "BirthName", ResourceType = typeof(Resources.Resources))]
        public string BirthName { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        public string FirstName { get; set; }

        [Display(Name = "MartialStatus", ResourceType = typeof(Resources.Resources))]
        public string MartialStatus { get; set; }

        [Display(Name = "NumberOfChildren", ResourceType = typeof(Resources.Resources))]
        [DefaultValue(0)]
        public int NumberOfChildren { get; set; }

        [Display(Name = "BirthDate", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "PlaceOfBirth", ResourceType = typeof(Resources.Resources))]
        public string PlaceOfBirth { get; set; }

        [Display(Name = "Nationality", ResourceType = typeof(Resources.Resources))]
        public string Nationality { get; set; }

        [Display(Name = "Mother", ResourceType = typeof(Resources.Resources))]
        public int MotherId { get; set; }

        [Display(Name = "Father", ResourceType = typeof(Resources.Resources))]
        public int FatherId { get; set; }

        [Display(Name = "Notes", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Display(Name = "Category", ResourceType = typeof(Resources.Resources))]
        public string Category { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        public string FullName;
    }
}