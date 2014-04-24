using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;

namespace CV.WebApplication.Controllers
{
    using CV.Model;
    using CV.DAL;

    public class SkillController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Skill/
        public ActionResult Index()
        {
            return View(db.Skills.ToList());
        }

        // GET: /Skill/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: /Skill/Create
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Skill/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung 
        // erfolgen soll. Weitere Informationen finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        //public ActionResult Create([Bind(Include = "ID,Title,Description,WebAddress")] Skill skill)
        public ActionResult Create([Bind(Include = "Title,Description,WebAddress")] Skill skill)
        {
            try
            {
            // :STC: End
                if (ModelState.IsValid)
                {
                    db.Skills.Add(skill);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            // :STC: Begin
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError(String.Empty, "Unable to save changes. Try again, and if the problem persists see your system administrator.");            
            }            
            return View(skill);
        }

        // GET: /Skill/Edit/5
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: /Skill/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung 
        // erfolgen soll. Weitere Informationen finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit([Bind(Include = "ID,Title,Description,WebAddress")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skill);
        }

        // GET: /Skill/Delete/5
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
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: /Skill/Delete/5
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
                //Skill skill = db.Skills.Find(id);
                //db.Skills.Remove(skill);                
                Skill entryToDelete = new Skill() { ID = id };
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
