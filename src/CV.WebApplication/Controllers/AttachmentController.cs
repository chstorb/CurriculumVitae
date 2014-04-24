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

    public class AttachmentController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // :STC: Begin
        /// <summary>
        /// The PopulatePeopleDropDownList method gets a list of all persons sorted by last name creates 
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

        // GET: /Attachment/
        public ActionResult Index()
        {
            var attachments = db.Attachments.Include(a => a.Person);
            return View(attachments.ToList());
        }

        // GET: /Attachment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // GET: /Attachment/Create
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Create()
        {
            //:STC: Start
            //ViewBag.ID = new SelectList(db.People, "ID", "LastName");            
            PopulatePeopleDropDownList();
            //:STC: End
            return View();
        }

        // POST: /Attachment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]        
        //public ActionResult Create([Bind(Include="ID,Title,AttachmentType,AttachmentDate,FileType,FilePath,Summary,ID")] Attachment attachment)
        public ActionResult Create([Bind(Include="PersonId,Title,AttachmentType,AttachmentDate,FileType,FilePath,Summary")] Attachment attachment)
        // :STC: End
        {
            // :STC: Begin
            try
            {
            // :STC: End
                if (ModelState.IsValid)
                {
                    db.Attachments.Add(attachment);
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
            //ViewBag.ID = new SelectList(db.People, "ID", "LastName", person.ID);
            PopulatePeopleDropDownList(attachment.PersonId);
            // :STC: End
            return View(attachment);
        }

        // GET: /Attachment/Edit/5
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            // :STC: Begin
            //ViewBag.ID = new SelectList(db.People, "ID", "LastName", person.ID);
            PopulatePeopleDropDownList(attachment.PersonId);
            // :STC: End
            return View(attachment);
        }

        // POST: /Attachment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit([Bind(Include="ID,PersonId,Title,AttachmentType,AttachmentDate,FileType,FilePath,Summary")] Attachment attachment)
        {
            // :STC: Begin
            try
            {
            // :STC: End
                if (ModelState.IsValid)
                {
                    db.Entry(attachment).State = EntityState.Modified;
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
            //ViewBag.ID = new SelectList(db.People, "ID", "LastName", person.ID);
            PopulatePeopleDropDownList(attachment.PersonId);
            // :STC: End            
            return View(attachment);
        }

        // GET: /Attachment/Delete/5
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
            Attachment attachment = db.Attachments.Find(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: /Attachment/Delete/5
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
                //Attachment attachment = db.Attachments.Find(id);
                //db.Attachments.Remove(attachment);                
                Attachment entryToDelete = new Attachment() { ID = id };
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
