/* Filename: ProfilesController.cs
 * Description: This class is responsible for handing the interaction between the user and Profiles.
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
    public class ProfilesController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: friend Profile
        public ActionResult Index(int? id)
        {
            string uname = this.User.Identity.Name;
            var friend_List = db.Friend_List.Where(f => f.user_id == id || f.friend_id == id);
            bool friend = friend_List.Any(f => f.User.username == uname || f.User1.username == uname);
            bool isUser = db.Users.Where(f => f.user_id == id).Any(f => f.username == uname);
            var profile = db.Users.Where(f => f.user_id == id);
            if (friend || isUser)
            {
                return View(profile.ToList());
            }
            else
            {
                return RedirectToAction("nonFriend", new { id });
            }
        }
        //GET: non friend profile
        public ActionResult nonFriend(int? id)
        {
            var profile = db.Users.Where(f => f.user_id == id);
            return View(profile.ToList());
        }

        public ActionResult MyIndex(string uname)
        {
            int id = db.Users.Where(u => u.username == this.User.Identity.Name).FirstOrDefault().user_id;
            return RedirectToAction("Index", new { id });
        }
    }
}