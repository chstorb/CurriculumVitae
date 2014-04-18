using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CV.Model
{
    /// <summary>
    /// Certification class.
    /// </summary>
    [MetadataTypeAttribute(typeof(CertificationMetadata))]
    public partial class Certification
    {
        /// <summary>
        /// Certification ID (primary key)
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Person ID (foreign key)
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Certification Name / Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Institution Name
        /// </summary>
        public string InstitutionName { get; set; }

        /// <summary>
        /// Date of Receipt
        /// </summary>
        public Nullable<DateTime> DateOfReceipt { get; set; }

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
        /// Summary
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Person navigation property
        /// </summary>
        public virtual Person Person { get; set; }
    }
}