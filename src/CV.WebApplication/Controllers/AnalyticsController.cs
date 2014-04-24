using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CV.WebApplication.Controllers
{
    using CV.DAL;
    using CV.Model;
    using CV.WebApplication.Models;
    using CV.WebApplication.ViewModels;

    public class AnalyticsController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Analytics/
        public ActionResult Index()
        {
            IQueryable<PersonResumeGroup> data = from resume in db.Resumes
                                                 group resume by resume.Person into resumeGroup
                                                 select new PersonResumeGroup
                                                 {
                                                     Person = resumeGroup.Key,
                                                     ResumeCount = resumeGroup.Count()
                                                 };
            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
