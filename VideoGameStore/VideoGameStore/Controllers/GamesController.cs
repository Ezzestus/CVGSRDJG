/* Filename: GamesController.cs
 * Description: This class is responsible for handing the interaction between the user and the Game model.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-23: Created
 *     David Klumpenhower, 2016-12-10 added search functionality 
*/

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    public class GamesController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // GET: Games
        [AllowAnonymous]
        public ActionResult Index(string search = "")
        {
            List<Game> gameList = new List<Game>();
            if (search == "")
            {
                var games = db.Games.Include(g => g.Developer).Include(g => g.Genre).Include(g => g.Publisher);
                gameList = games.ToList();
            }
            else
            {
                var games = db.Games.Include(g => g.Developer).Include(g => g.Genre).Include(g => g.Publisher).Where(g => g.game_name.Contains(search));
                gameList = games.ToList();
            }

            List<AverageGameRating> gamesWithAverageRatings = new List<AverageGameRating>();
            gamesWithAverageRatings = getAverageGameRatings(gameList);
            return View(gamesWithAverageRatings);
        }

        // GET: Games/Details/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.developer_id = new SelectList(db.Developers, "developer_id", "developer_name");
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name");
            ViewBag.publisher_id = new SelectList(db.Publishers, "publisher_id", "publisher_name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "game_id,game_name,description,cost,list_price,on_hand,developer_id,publisher_id,genre_id,release_date,is_on_sale,is_discontinued,is_downloadable,is_physical_copy,image_location")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.developer_id = new SelectList(db.Developers, "developer_id", "developer_name", game.developer_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", game.genre_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "publisher_id", "publisher_name", game.publisher_id);
            return View(game);
        }

        // GET: Games/Edit/5
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.developer_id = new SelectList(db.Developers, "developer_id", "developer_name", game.developer_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", game.genre_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "publisher_id", "publisher_name", game.publisher_id);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "game_id,game_name,description,cost,list_price,on_hand,developer_id,publisher_id,genre_id,release_date,is_on_sale,is_discontinued,is_downloadable,is_physical_copy,image_location")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.developer_id = new SelectList(db.Developers, "developer_id", "developer_name", game.developer_id);
            ViewBag.genre_id = new SelectList(db.Genres, "genre_id", "genre_name", game.genre_id);
            ViewBag.publisher_id = new SelectList(db.Publishers, "publisher_id", "publisher_name", game.publisher_id);
            return View(game);
        }

        // GET: Games/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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

        public void insertDefaultRatings()
        {
            SharedDB.setConnectionString();
            using (SharedDB.connection)
            {
                SharedDB.connection.Open();
                SharedDB.command = new MySqlCommand("INSERT INTO User_Game (user_game_id, user_id, game_id, date_purchased, rating) VALUES (8, 1, 3, 01-01-2001, 5), " +
                    "(9, 2, 3, 01-01-2001, 4), (10, 3, 3, 01-01-2001, 4), (11, 4, 3, 01-01-2001, 4), (12, 5, 3, 01-01-2001, 4)", SharedDB.connection);
                SharedDB.command.ExecuteNonQuery();
            }
        }

        public List<AverageGameRating> getAverageGameRatings(List<Game> games)
        {
            double rating = 0f;
            List<AverageGameRating> ratingResults = new List<AverageGameRating>();

            foreach (Game game in games)
            {
                AverageGameRating averageGame = new AverageGameRating();
                var ratings = db.User_Game.Include(g => g.rating).Where(g => g.game_id == game.game_id);
                if (ratings.Count() > 0)
                {
                    rating = Math.Round((double)Double.Parse(ratings.Sum(r => r.rating).ToString()) / Double.Parse(ratings.Count().ToString()),1);
                    averageGame.averageRating = rating.ToString();
                }
                else
                {
                    averageGame.averageRating = "N/A";


                }
                averageGame.game_id = game.game_id;
                averageGame.game_name = game.game_name;
                averageGame.description = game.description;
                averageGame.cost = game.cost;
                averageGame.list_price = game.list_price;
                averageGame.on_hand = game.on_hand;
                averageGame.developer_name = game.Developer.developer_name;
                averageGame.publisher_name = game.Publisher.publisher_name;
                averageGame.genre = game.Genre.genre_name;
                averageGame.release_date = game.release_date;
                averageGame.is_on_sale = game.is_on_sale;
                averageGame.is_discontinued = game.is_discontinued;
                averageGame.is_downloadable = game.is_downloadable;
                averageGame.is_physical_copy = game.is_physical_copy;
                averageGame.image_location = game.image_location;
                ratingResults.Add(averageGame);
            }
            return ratingResults;
        }
    }
}
