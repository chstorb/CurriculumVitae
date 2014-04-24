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
    using System.Data.Entity.Infrastructure;

    public class ResumeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // :STC: Begin
        /// <summary>
        /// The PopulatePeopleDropDownList method gets a list of all People sorted by last name, creates 
        /// a SelectList collection for a drop-down list, and passes the collection to the view in a 
        /// ViewBag property. The method accepts the optional id parameter that allows the calling code 
        /// to specify the item that will be selected when the drop-down list is rendered. 
        /// The view will pass the name PersonId to the DropDownList helper, and the helper then knows 
        /// to look in the ViewBag object for a SelectList named PersonId.
        /// </summary>
        /// <param name="id"></param>
        private void PopulatePeopleDropDownList(object id = null)
        {
            var qry = from p in db.People
                      orderby p.LastName
                      select p; 
            ViewBag.PersonId = new SelectList(qry, "ID", "LastName", id);
        }
        // :STC: End

        // GET: /Resume/
        // :STC: Begin
        //public ActionResult Index()
        //{
        //    var resumes = db.Resumes.Include(r => r.Person);
        //    return View(resumes.ToList());
        //}
        public ActionResult Index(int? id, int? experienceID)
        {
            var viewModel = new ViewModels.ResumeData();
            viewModel.Resumes = db.Resumes
                .Include(r => r.Person)
                .Include(r => r.Experiences.Select(s => s.SkillMatrix.Select(k => k.Skill)))
                .OrderBy(r => r.AvailabilityDate);

            if (id != null)
            {
                ViewBag.ResumeId = id.Value;
                
                viewModel.Experiences = viewModel.Resumes.Where(r => r.ID == id.Value)
                    .Single().Experiences;
            }

            if (experienceID != null)
            {
                ViewBag.ExperienceId = experienceID.Value;
                viewModel.SkillMatrix = viewModel.Experiences.Where(e => e.ID == experienceID)
                    .Single().SkillMatrix;
            }

            return View(viewModel);
        }
        // :STC: End

        // GET: /Resume/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // GET: /Resume/Create
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Create()
        {
            //:STC: Begin
            //ViewBag.PersonId = new SelectList(db.People, "ID", "LastName");
            PopulatePeopleDropDownList();
            //:STC: End
            return View();
        }

        // POST: /Resume/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]        
        //public ActionResult Create([Bind(Include = "ID,Title,Visible,WorkAuthorisationFor,CurrentCareerLevel,CurrentEducationLevel,SalaryFrom,SalaryTo,PreferredCountry,PreferredLocation,DesiredJobType,DesiredJobStatus,TavelDaysPerMonth,AvailabilityDate,Notes,ID")] Resume resume)
        public ActionResult Create([Bind(Include = "PersonId,Title,Visible,WorkAuthorisationFor,CurrentCareerLevel,CurrentEducationLevel,SalaryFrom,SalaryTo,PreferredCountry,PreferredLocation,DesiredJobType,DesiredJobStatus,TavelDaysPerMonth,AvailabilityDate,Notes")] Resume resume)        
        {
            try
            {
            // :STC: End
                if (ModelState.IsValid)
                {
                    db.Resumes.Add(resume);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            // :STC: Begin
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError(String.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }            
            //ViewBag.PersonId = new SelectList(db.People, "ID", "LastName", resume.PersonId);
            PopulatePeopleDropDownList(resume.PersonId);
            // :STC: End
            return View(resume);
        }

        // GET: /Resume/Edit/5
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            // :STC: Begin
            //ViewBag.PersonId = new SelectList(db.People, "ID", "LastName", resume.PersonId);
            PopulatePeopleDropDownList(resume.PersonId);
            // :STC: End

            return View(resume);
        }

        // POST: /Resume/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit([Bind(Include = "ID,PersonId,Title,Visible,WorkAuthorisationFor,CurrentCareerLevel,CurrentEducationLevel,SalaryFrom,SalaryTo,PreferredCountry,PreferredLocation,DesiredJobType,DesiredJobStatus,TavelDaysPerMonth,AvailabilityDate,Notes")] Resume resume)
        {
            // :STC: Begin
            try
            {
                // :STC: End
                if (ModelState.IsValid)
                {
                    db.Entry(resume).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                // :STC: Begin
            }
            catch (DbUpdateException duex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", duex.Message);
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError(String.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }            
            //ViewBag.PersonId = new SelectList(db.People, "ID", "LastName", resume.PersonId);
            PopulatePeopleDropDownList(resume.PersonId);
            // :STC: End
            return View(resume);
        }

        // GET: /Resume/Delete/5
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
            // :STC Start
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            // :STC End
            Resume resume = db.Resumes.Find(id);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        // POST: /Resume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        //public ActionResult DeleteConfirmed(int id)
        public ActionResult Delete(int id)
        // :STC End
        {
            // :STC: Begin
            try
            {
                //Resume resume = db.Resumes.Find(id);
                //db.Resumes.Remove(resume);                
                Resume entryToDelete = new Resume() { ID = id };
                db.Entry(entryToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            // :STC End
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
