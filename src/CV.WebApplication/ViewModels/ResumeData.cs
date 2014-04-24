using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CV.WebApplication.ViewModels
{
    using CV.Model;

    public class ResumeData
    {
        public IEnumerable<Resume> Resumes { get; set; }

        public IEnumerable<Experience> Experiences { get; set; }

        public IEnumerable<SkillMatrix> SkillMatrix { get; set; }

        //public IEnumerable<Skill> Skills { get; set; }

        public IEnumerable<Education> Education { get; set; }

        public IEnumerable<Certification> Certifications { get; set; }

        public IEnumerable<Language> Languages { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; }
    }
}