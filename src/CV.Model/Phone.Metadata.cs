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
    /// PhoneMetadata class.
    /// </summary>
    public sealed class PhoneMetadata
    {
        private PhoneMetadata() { }

        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }
    }
}
