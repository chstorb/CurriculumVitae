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

    public class AddressController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Address/
        public ActionResult Index()
        {
            var contactdetails = db.ContactDetails.Include(a => a.Person);
            return View(contactdetails.ToList());
        }

        public PartialViewResult GetByPersonId(int id)
        {
            ViewBag.PersonId = id;
            List<Address> addressList = db.Addresses.Where(a => a.PersonId == id).ToList();
            return PartialView("_AddressIndex", addressList);
        }

        // GET: /Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.ContactDetails.Find(id) as Address;
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: /Address/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "ID", "LastName");
            return View();
        }

        // POST: /Address/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PersonId,Usage,Street,City,StateProvince,ZipPostalCode,CountryRegion")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.ContactDetails.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "ID", "LastName", address.PersonId);
            return View(address);
        }

        // GET: /Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.ContactDetails.Find(id) as Address;
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "ID", "LastName", address.PersonId);
            return View(address);
        }

        // POST: /Address/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PersonId,Usage,Street,City,StateProvince,ZipPostalCode,CountryRegion")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.People, "ID", "LastName", address.PersonId);
            return View(address);
        }

        // GET: /Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.ContactDetails.Find(id) as Address;
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: /Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.ContactDetails.Find(id) as Address;
            db.ContactDetails.Remove(address);
            db.SaveChanges();
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
