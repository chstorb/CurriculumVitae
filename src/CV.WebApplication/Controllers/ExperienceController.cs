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
    // :STC: Begin
    using CV.DAL;
    using CV.Model;
    using CV.WebApplication.Models;
    using PagedList;
    using System.Data.Entity.Infrastructure;
    // :STC: End

    public class ExperienceController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // :STC: Begin
        /// <summary>
        /// The PopulateResumesDropDownList method gets a list of all resumes sorted by title, creates 
        /// a SelectList collection for a drop-down list, and passes the collection to the view in a 
        /// ViewBag property. The method accepts the optional id parameter that allows the calling code 
        /// to specify the item that will be selected when the drop-down list is rendered. 
        /// The view will pass the name ResumeId to the DropDownList helper, and the helper then knows 
        /// to look in the ViewBag object for a SelectList named ResumeId.
        /// </summary>
        /// <param name="id"></param>
        private void PopulateResumesDropDownList(object id = null)
        {
            var qry = from r in db.Resumes
                      orderby r.Title
                      select r;
            ViewBag.ResumeId = new SelectList(qry, "ID", "Title", id);
        }
        // :STC: End

        // GET: /Experience/
        // :STC: Begin
        //public ActionResult Index()
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        // :STC: End
        {
            // :STC: Begin
            //var experiences = db.Experiences.Include(e => e.Resume);
            //return View(experiences.ToList());

            ViewBag.CurrentSort = sortOrder;
            ViewBag.EndDateSortParm = String.IsNullOrEmpty(sortOrder) ? "enddate_desc" : "";
            ViewBag.StartDateSortParm = sortOrder == "startdate_asc" ? "startdate_desc" : "startdate_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else 
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var experiences = from e in db.Experiences
                              select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                experiences = experiences.Where(e => e.Employer.ToUpper().Contains(searchString.ToUpper())
                    || e.Employer.ToUpper().Contains(searchString.ToUpper()));
            }
                        
            switch (sortOrder)
            {
                case "enddate_desc":
                    experiences = experiences.OrderByDescending(e => e.EndDate);
                    break;
                case "startdate_asc":
                    experiences = experiences.OrderBy(e => e.StartDate);
                    break;
                case "startdate_desc":
                    experiences = experiences.OrderByDescending(e => e.StartDate);
                    break;
                default:
                    experiences = experiences.OrderBy(s => s.EndDate);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(experiences.ToPagedList(pageNumber, pageSize));
            // :STC: End            
        }

        // GET: /Experience/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // GET: /Experience/Create
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Create()
        {
            // :STC: Begin
            //ViewBag.ResumeId = new SelectList(db.Resumes, "ID", "Title");
            PopulateResumesDropDownList();
            // :STC: End
            return View();
        }

        // POST: /Experience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]         
        //public ActionResult Create([Bind(Include="ID,Employer,JobTitle,Industry,City,StateProvince,CountryRegion,Description,StartDate,EndDate,Responsibilities,Visible,ID")] Experience experience)
        public ActionResult Create([Bind(Include = "ResumeId,Employer,JobTitle,Industry,City,StateProvince,CountryRegion,Description,StartDate,EndDate,Responsibilities,Visible")] Experience experience)
        {
            try
            {
            // :STC: End
                if (ModelState.IsValid)
                {
                    db.Experiences.Add(experience);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            // :STC: Begin
            }
            catch (RetryLimitExceededException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //ViewBag.ResumeId = new SelectList(db.Resumes, "ID", "Title", experience.ResumeId);
            PopulateResumesDropDownList(experience.ResumeId);
            // :STC: End
            return View(experience);
        }

        // GET: /Experience/Edit/5
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            // :STC: Begin
            //ViewBag.ResumeId = new SelectList(db.Resumes, "ID", "Title");
            PopulateResumesDropDownList(experience.ResumeId);
            // :STC: End
            return View(experience);
        }

        // POST: /Experience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit([Bind(Include="ID,ResumeId,Employer,JobTitle,Industry,City,StateProvince,CountryRegion,Description,StartDate,EndDate,Responsibilities,Visible")] Experience experience)
        {
            // :STC: Begin
            try
            {
            // :STC: End
                if (ModelState.IsValid)
                {
                    db.Entry(experience).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            // :STC: Begin
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //ViewBag.ResumeId = new SelectList(db.Resumes, "ID", "Title", experience.ResumeId);
            PopulateResumesDropDownList(experience.ResumeId);
            // :STC: End
            return View(experience);
        }

        // GET: /Experience/Delete/5
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        //public ActionResult Delete(int? id)
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        // :STC: End
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // :STC: Begin
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            // :STC: End
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
        }

        // POST: /Experience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        //public ActionResult DeleteConfirmed(int id)
        public ActionResult Delete(int id)
        // :STC: End
        {
            // :STC: Begin
            try
            {
                //Experience experience = db.Experiences.Find(id);
                //db.Experiences.Remove(experience);                
                Experience entryToDelete = new Experience() { ID = id };
                db.Entry(entryToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            // :STC: End
            return RedirectToAction("Index");
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
