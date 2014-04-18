using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Model
{
    using CV.Common;

    /// <summary>
    /// WebSiteMetadata class.
    /// </summary>
    [Table(Constants.TablePrefix + "ContactDetail")]
    public sealed class WebSiteMetadata
    {
        private WebSiteMetadata() { }

        [DisplayName("Website")]
        public string WebAddress { get; set; }
    }
}
