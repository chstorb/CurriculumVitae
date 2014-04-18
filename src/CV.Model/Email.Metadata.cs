using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Model
{
    /// <summary>
    /// EmailMetadata class.
    /// </summary>
    public sealed class EmailMetadata
    {
        private EmailMetadata() {}

        [DisplayName("E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string EMailAddress { get; set; }
    }
}
