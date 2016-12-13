/* Filename: User_GameController.cs
 * Description: This class is responsible for handing the interaction between the user and the User Game model.
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
using System.Security.Claims;

namespace VideoGameStore.Controllers
{
    public class User_GameController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        /// <summary>
        /// Gets the games that belong to the user or the games that belong and match the search criteria and hands them to the index view
        /// </summary>
        /// <param name="search">search criteria</param>
        /// <returns>list of games owned by the user</returns>
        public ActionResult Index(string search ="")
        {
            //declarations
            int userID = db.Users.Where(u => u.username == this.User.Identity.Name).FirstOrDefault().user_id;
            ViewBag.Search = "";
            var gamesQuery = (
                from userGames in db.User_Game
                join games in db.Games on userGames.game_id equals games.game_id
                where (userGames.user_id == userID)
                select new
                {
                    userGameID = userGames.user_game_id,
                    gameID = games.game_id,
                    imageLocation = games.image_location,
                    description = games.description,
                    gameName = games.game_name,
                    rating = userGames.rating,
                    datePurchased = userGames.date_purchased
                }).ToList();

            //check if user is searching
            if (search != "")
            {
                gamesQuery = (
                from userGames in db.User_Game
                join games in db.Games on userGames.game_id equals games.game_id
                where (userGames.user_id == userID)
                where (games.game_name.Contains(search))
                select new
                {
                    userGameID = userGames.user_game_id,
                    gameID = games.game_id,
                    imageLocation = games.image_location,
                    description = games.description,
                    gameName = games.game_name,
                    rating = userGames.rating,
                    datePurchased = userGames.date_purchased
                }).ToList();
                if(gamesQuery.Count() ==0)
                {
                    ViewBag.Search = search;
                }
            }
            else
            {
                gamesQuery = (
                from userGames in db.User_Game
                join games in db.Games on userGames.game_id equals games.game_id
                where (userGames.user_id == userID)
                where( games.game_name.Contains(search))
                select new
                {
                    userGameID = userGames.user_game_id,
                    gameID = games.game_id,
                    imageLocation = games.image_location,
                    description = games.description,
                    gameName = games.game_name,
                    rating = userGames.rating,
                    datePurchased = userGames.date_purchased
                }).ToList();
            }

            
            //left join the users games with the review table
            List<UserGameViewModel> gamesQueryList = new List<UserGameViewModel>();
            foreach (var item in gamesQuery)
            {
                var reviewCheck = (
                from r in db.Reviews
                where (item.gameID == r.game_id)
                where (r.user_id == userID)
                select r
                ).ToList();
                Review review = new Review();
                foreach(var r in reviewCheck)
                {
                    review = r;
                }

                //add game to the list of games
                UserGameViewModel game = new UserGameViewModel();
                game.userGameID = item.userGameID;
                game.gameID = item.gameID;
                game.imageLocation = item.imageLocation;
                game.description = item.description;
                game.gameName = item.gameName;
                game.rating = item.rating;
                game.datePurchased = item.datePurchased;
                game.reviewID = review.review_id;

                gamesQueryList.Add(game);
            }

            return View(gamesQueryList);
        }

        /// <summary>
        /// Allows the user to edit the rating of a game
        /// </summary>
        /// <param name="id">game id</param>
        /// <param name="reviewID">id of the users review if the user has reviewed the game</param>
        /// <returns>rating  view</returns>
        public ActionResult Edit(int? id, int? reviewID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Game user_Game = db.User_Game.Find(id);
            if (user_Game == null)
            {
                return HttpNotFound();
            }

            //generate drop down list for rating
            List<int> rating = new List<int>();
            for (int i = 1; i < 6; i++)
            {
                rating.Add(i);
            }
            ViewBag.reviewID = reviewID;
            ViewBag.rating = new SelectList(rating, user_Game.rating);
            return View(user_Game);
        }

        // POST: User_Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_game_id,user_id,game_id,date_purchased,rating")] User_Game user_Game)
        {
            //save changes
            if (ModelState.IsValid)
            {
                db.Entry(user_Game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Game);
        }

        // GET: User_Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Game user_Game = db.User_Game.Find(id);
            if (user_Game == null)
            {
                return HttpNotFound();
            }
            return View(user_Game);
        }

        // POST: User_Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Game user_Game = db.User_Game.Find(id);
            db.User_Game.Remove(user_Game);
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
