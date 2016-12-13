﻿/* Filename: ReviewsController.cs
 * Description: This class is responsible for handing the interaction between the user and the Review model.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-23: Created
 *     David Klunmpenhower Edited 
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
    public class ReviewsController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        /// <summary>
        /// gets a list of user reviews for a game to display to the user
        /// </summary>
        /// <param name="id">game id</param>
        /// <returns>list of reviews</returns>
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                var reviews = db.Reviews.Include(r => r.Game).Include(r => r.User).Where(r => r.game_id == id);
                return View(reviews.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Games");
            }
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        /// <summary>
        /// allows the user to creaete a review of a game they own if they haven't reviewed it yet
        /// </summary>
        /// <param name="userGameID">id of entry in the user_game table</param>
        /// <returns></returns>
        public ActionResult Create(int? userGameID)
        {
            Review review = new Review();

            //verify that the user owns the game
            if (userGameID != null)
            {
                User_Game userGame = db.User_Game.Find(userGameID);
                ViewBag.rating = userGame.rating;
                ViewBag.rating = userGame.rating;

                Game game = db.Games.Find(userGame.game_id);

                User user = db.Users.Find(userGame.user_id);

                review.Game = game;
                review.User = user;
                review.user_id = user.user_id;
                review.game_id = game.game_id;
                review.review_date = DateTime.Now;
                review.review_content = "";
                review.is_approved = false;
                review.is_deleted = false;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            ViewBag.userGameID = userGameID;
            return View(review);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "review_id,user_id,game_id,review_date,review_content,is_approved,is_deleted")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }

        /// <summary>
        /// allow the user to modify their review or an admin to aprove it
        /// </summary>
        /// <param name="id">review id</param>
        /// <param name="userGameID">user game id</param>
        /// <param name="isAdmin">check if admin is trying to aprove reviews</param>
        /// <returns></returns>
        public ActionResult Edit(int? id, int? userGameID, bool? isAdmin) { 
        
            //check that there is a review
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //find the review
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }

            //check that the user owns the game
            if (userGameID != null)
            {
                User_Game userGame = db.User_Game.Find(userGameID);
                ViewBag.datePurchased = userGame.date_purchased;
                ViewBag.rating = userGame.rating;
            }

            ViewBag.userGameID = userGameID;

            //check if the admin is trying to approve reviews
            if (isAdmin != null)
            {
                ViewBag.isAdmin = isAdmin;
            }
            else
            {
                ViewBag.isAdmin = false;
            }
            ViewBag.oldReview = review.review_content;

                return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "review_id,user_id,game_id,review_date,review_content,is_approved,is_deleted")] Review review)
        {

            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }
        public ActionResult checkReviewChanges(Review review)
        {
            //check if the user changed their review if they did unaprove it
            var oldReviewContent = db.Reviews.Find(review.review_id);
            if (review.review_content != oldReviewContent.review_content)
            {
                if (review.is_approved)
                {
                    review.is_approved = false;
                }
            }
            return RedirectToAction("Edit", review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
