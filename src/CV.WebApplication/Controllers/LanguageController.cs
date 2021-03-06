﻿using System;
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
    using System.Data.Entity.Infrastructure;

    public class LanguageController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // :STC: Begin
        /// <summary>
        /// The PopulatePeopleDropDownList method gets a list of all people sorted by LastName, creates 
        /// a SelectList collection for a drop-down list, and passes the collection to the view in a 
        /// ViewBag property. The method accepts the optional id parameter that allows the calling code 
        /// to specify the item that will be selected when the drop-down list is rendered. 
        /// The view will pass the name PersonId to the DropDownList helper, and the helper then knows 
        /// to look in the ViewBag object for a SelectList named PersonId.
        /// </summary>
        /// <param name="id"></param>
        private void PopulatePeopleDropDownList(object id = null)
        {
            //var qry = from p in db.People
            //          orderby p.LastName 
            //          select p;
            //ViewBag.PersonId = new SelectList(qry, "ID", "LastName", id);
            var qry = db.People.ToList();
            IEnumerable<SelectListItem> selectList = from p in qry
                      orderby p.FullName
                      select new SelectListItem
                      {
                          Value = p.ID.ToString(),
                          Text = p.FullName.ToString()
                      };
            ViewBag.PersonId = new SelectList(selectList, "Value", "Text", id);
        }
        // :STC: End

        // GET: /Language/
        public ActionResult Index()
        {
            var languages = db.Languages.Include(l => l.Person);
            return View(languages.ToList());
        }

        // GET: /Language/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // GET: /Language/Create
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

        // POST: /Language/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung 
        // erfolgen soll. Weitere Informationen finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        //public ActionResult Create([Bind(Include = "ID,PersonId,LanguageName,Level")] Language language)
        public ActionResult Create([Bind(Include = "PersonId,LanguageName,Level")] Language language)
        {
            try
            {
            // :STC: End
                if (ModelState.IsValid)
                {
                    db.Languages.Add(language);
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
            //ViewBag.PersonId = new SelectList(db.People, "ID", "LastName", language.PersonId);
            // :STC: End
            PopulatePeopleDropDownList(language.PersonId);
            return View(language);
        }

        // GET: /Language/Edit/5
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            // :STC: Begin
            //ViewBag.PersonId = new SelectList(db.Resumes, "ID", "Title", language.PersonId);
            // :STC: End
            PopulatePeopleDropDownList(language.PersonId);
            return View(language);
        }

        // POST: /Language/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung 
        // erfolgen soll. Weitere Informationen finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // :STC: Begin
        [Authorize(Roles = "canEdit")]
        // :STC: End
        public ActionResult Edit([Bind(Include = "ID,PersonId,LanguageName,Level")] Language language)
        {
            // :STC: Begin
            try
            {
            // :STC: End
                if (ModelState.IsValid)
                {
                    db.Entry(language).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            // :STC: Begin
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }            
            //ViewBag.PersonId = new SelectList(db.People, "ID", "LastName", language.PersonId);
            // :STC: End
            PopulatePeopleDropDownList(language.PersonId);
            return View(language);
        }

        // GET: /Language/Delete/5
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
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: /Language/Delete/5
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
                //Language language = db.Languages.Find(id);
                //db.Languages.Remove(language);
                Language entryToDelete = new Language() { ID = id };
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
