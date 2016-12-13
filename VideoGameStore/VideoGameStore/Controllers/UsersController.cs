/* Filename: UsersController.cs
 * Description: This class is responsible for handing the interaction between the user and the User model.
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
using System.Web.Helpers;
using System.Web.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    public class UsersController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Users
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated || User.IsInRole("Customer") || User.IsInRole("Member"))
            {
                var customersMembers = db.Users.Where(c => c.is_member == true || c.is_employee == false);
                return View(customersMembers.ToList());
            }
            return View(db.Users.ToList());
        }

        // Get users that are members
        public ActionResult Members()
        {
            var members = db.Users.Where(m => m.is_member == true);
            return View("Index", members.ToList());
        }

        // Get users that are customers
        public ActionResult Customers()
        {
            var customers = db.Users.Where(m => m.is_employee == false);
            return View("Index", customers.ToList());
        }

        // Get users that are Employees
        public ActionResult Employees()
        {
            var employees = db.Users.Where(m => m.is_employee == true);
            return View("Index", employees.ToList());
        }

        // GET: Users/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,username,email,user_password,login_failures,first_name,last_name,phone,gender,birthdate,date_joined,is_employee,is_admin,is_member,is_inactive,is_locked_out,is_on_email_list,favorite_platform,favorite_category,notes")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!User.IsInRole("Admin") || !User.IsInRole("Employee"))
            {
                if(db.Users.Where(u => u.username == User.Identity.Name).FirstOrDefault().user_id == id)
                {
                    User currentUser = db.Users.Find(id);
                    if (currentUser == null)
                    {
                        return HttpNotFound();
                    }
                    return View(currentUser);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }
            }
            else
            {
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }                        
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,username,email,user_password,login_failures,first_name,last_name,phone,gender,birthdate,date_joined,is_employee,is_admin,is_member,is_inactive,is_locked_out,is_on_email_list,favorite_platform,favorite_category,notes")] User user)
        {
            if (ModelState.IsValid)
            {
                user.user_password = Crypto.HashPassword(user.user_password);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        // POST: Users/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
