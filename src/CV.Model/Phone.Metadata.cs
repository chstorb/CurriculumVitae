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

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }
    }
}
