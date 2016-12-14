/* Filename: Wish_ListController.cs
 * Description: This class is responsible for handing the interaction between the user and the Wish List model.
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
    public class Wish_ListController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Wish_List
        public ActionResult Index(int? id)
        {
            var wish_List = db.Wish_List.Where(f => f.user_id == id);
            ViewBag.return_id = id;
            return View(wish_List.ToList());
        }

        // GET: Wish_List/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish_List wish_List = db.Wish_List.Find(id);
            if (wish_List == null)
            {
                return HttpNotFound();
            }
            return View(wish_List);
        }

        // GET: Wish_List/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish_List wish_List = db.Wish_List.Find(id);
            if (wish_List == null)
            {
                return HttpNotFound();
            }
            ViewBag.return_id = wish_List.user_id;
            return View(wish_List);
        }

        // POST: Wish_List/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wish_List wish_List = db.Wish_List.Find(id);
            db.Wish_List.Remove(wish_List);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = wish_List.user_id });
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