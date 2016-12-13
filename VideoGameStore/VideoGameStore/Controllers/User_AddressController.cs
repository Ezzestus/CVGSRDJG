/* Filename: User_AddressController.cs
 * Description: This class is responsible for handing the interaction between the user and the User Address model.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-23: Created 
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    public class User_AddressController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: User_Address
        public ActionResult Index()
        {
            int user_id = db.Users.Where(u => u.username == this.User.Identity.Name).FirstOrDefault().user_id;
            var user_Address = db.User_Address.Include(u => u.Address).Include(u => u.User).Where(u => u.user_id == user_id);
            return View(user_Address.ToList());
        }

        // GET: User_Address/Create
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Create()
        {
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "username");
            return View();
        }

        // POST: User_Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,address_id,address_name")] User_Address user_Address)
        {
            if (ModelState.IsValid)
            {
                db.User_Address.Add(user_Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", user_Address.address_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "username", user_Address.user_id);
            return View(user_Address);
        }

        // GET: User_Address/Edit/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Address user_Address = db.User_Address.Find(id);
            if (user_Address == null)
            {
                return HttpNotFound();
            }
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", user_Address.address_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "username", user_Address.user_id);
            return View(user_Address);
        }

        // POST: User_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,address_id,address_name")] User_Address user_Address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.address_id = new SelectList(db.Addresses, "address_id", "street_address", user_Address.address_id);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "username", user_Address.user_id);
            return View(user_Address);
        }

        // GET: User_Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Address user_Address = db.User_Address.Where(u => u.address_id == id).FirstOrDefault();
            if (user_Address == null)
            {
                return HttpNotFound();
            }
            return View(user_Address);
        }

        // POST: User_Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int user_id = db.Users.Where(u => u.username == User.Identity.Name).FirstOrDefault().user_id;
            User_Address user_Address = db.User_Address.Find(user_id, id);
            db.User_Address.Remove(user_Address);
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