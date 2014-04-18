using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Model
{
    /// <summary>
    /// WebSite class.
    /// </summary>
    [MetadataTypeAttribute(typeof(WebSiteMetadata))]
    public partial class WebSite : ContactDetail
    {
        private static string[] validUsageValues = new string[] { "Business", "Home" };

        public override IEnumerable<string> ValidUsageValues
        {
            get { return validUsageValues; }
        }
       
        public string WebAddress { get; set; }
    }
}
