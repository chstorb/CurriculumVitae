using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CV.WebApplication.ViewModels
{
    using CV.Model;

    public class PersonResumeGroup
    {
        public Person Person { get; set; }

        public int ResumeCount { get; set; }
    }
}