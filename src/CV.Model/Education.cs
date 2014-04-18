using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    /// <summary>
    /// Education class.
    /// </summary>
    [MetadataTypeAttribute(typeof(EducationMetadata))]
    public partial class Education
    {
        // Education ID (primary key)
        public int ID { get; set; }

        /// <summary>
        /// Person ID (foreing key)
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// School / Institution
        /// </summary>
        public string SchoolInstitution { get; set; }

        /// <summary>
        /// Degree
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// Date from
        /// </summary>
        public Nullable<DateTime> DateFrom { get; set; }

        /// <summary>
        /// Date to
        /// </summary>
        public Nullable<DateTime> DateTo { get; set; }

        /// <summary>
        /// Concentrations
        /// </summary>
        public string Concentrations { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State / Province
        /// </summary>
        public string StateProvince { get; set; }

        /// <summary>
        /// Country / Region
        /// </summary>
        public string CountryRegion { get; set; }       

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Person navigation property
        /// </summary>
        public virtual Person Person { get; set;}
    }
}