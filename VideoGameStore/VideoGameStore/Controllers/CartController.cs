/* Filename: CartController.cs
 * Description: This class is responsible for handing the interaction between the user and the Cart model.
 *
 * Note: Some of this code was adapted from example code found in Chapter 9 of "Pro ASP.NET MVC 5" by Adam Freeman.
 * 
 * Revision History:
 *     Ryan Pease, 2016-11-29: Created
 *     David Klumpenhower edited so cart also saves games to your library 
*/

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameStore.Models;

namespace VideoGameStore.Controllers
{
    public class CartController : Controller
    {
        private VideoGameStoreDBContext db = new VideoGameStoreDBContext();

        // This method is responsible for displaying the cart summary in the shared layout's navbar.
        [AllowAnonymous]
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        //GET: Cart
        [AllowAnonymous]
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        // This method is responsible for when a user requests to check out their cart.
        //GET: Checkout
        [Authorize(Roles = "Customer, Admin, Employee, Member")]
        public ViewResult Checkout()
        {
            int user_id = db.Users.Where(u => u.username == this.User.Identity.Name).FirstOrDefault().user_id;
            var addresses = db.User_Address.Where(a => a.user_id == user_id).ToList();
            var creditcards = db.Credit_Card.Where(c => c.user_id == user_id).ToList();
            int numAddresses = addresses.Count();
            int numCards = creditcards.Count();
            ViewBag.numCards = numCards;
            ViewBag.numAddresses = numAddresses;
            ViewBag.user_id = user_id;
            ViewBag.address_id = new SelectList(addresses, "address_id", "Address.street_address");
            ViewBag.credit_card_id = new SelectList(creditcards, "credit_card_id", "card_number");

            return View();
        }

        // This action is responsible for converting the cart into an invoice.
        //POST: Checkout
        [HttpPost]
        [Authorize(Roles = "Customer, Admin, Employee, Member")]
        public ActionResult Checkout(int address_id, int credit_card_id)
        {
            int user_id = db.Users.Where(u => u.username == this.User.Identity.Name).FirstOrDefault().user_id;
            Cart cart = GetCart();
            if (cart.Items == null || cart.Items.Count() == 0)
            {
                TempData["Message"] = "Invalid Submission: You cannot checkout without any items in your cart...";
                return Checkout();
            }
            else
            {
                Invoice invoice = new Invoice();
                invoice.user_id = user_id;
                invoice.credit_card_id = credit_card_id;
                invoice.invoice_date = DateTime.Now;
                db.Invoices.Add(invoice);
                db.SaveChanges();

                // Get the  id of most recently inserted invoice
                int invoiceNumber = db.Invoices.Max(i => i.invoice_id);

                // Create an invoice address based on user's selected address for billing address
                Invoice_Address invoiceAddress = new Invoice_Address();
                invoiceAddress.address_id = address_id;
                invoiceAddress.invoice_id = invoiceNumber;
                invoiceAddress.is_billing_address = true;
                db.Invoice_Address.Add(invoiceAddress);

                // get items in cart
                foreach (CartLineItem item in cart.Items)
                {
                    // Create a line item based on each item and add to database
                    Line_Item line_item = new Line_Item();
                    line_item.invoice_id = invoiceNumber;
                    line_item.game_id = item.Game.game_id;
                    line_item.quantity = item.Quantity;
                    line_item.price = item.Game.list_price;
                    db.Line_Item.Add(line_item);

                    User_Game game = new User_Game();
                    game.user_id = user_id;
                    game.game_id = item.Game.game_id;
                    game.date_purchased = DateTime.Today;
                    game.rating = 0;
                    db.User_Game.Add(game);

                    db.SaveChanges();
                }
                // Clear out cart data
                Session["Cart"] = new Cart();
                return RedirectToAction("DisplayUserInvoice", "Invoices", new { id = invoiceNumber });
            }
        }

        // This method is responsible for adding an item to the cart.
        [AllowAnonymous]
        public RedirectToRouteResult AddToCart(int game_id, string returnUrl)
        {
            Game game = db.Games.Where(g => g.game_id == game_id).FirstOrDefault();
            if (game != null)
            {
                GetCart().AddItem(game, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        // This method is responsible for removing an item from the cart.
        [AllowAnonymous]
        public RedirectToRouteResult RemoveFromCart(int game_id, string returnUrl)
        {
            Game game = db.Games.Where(g => g.game_id == game_id).FirstOrDefault();
            if (game != null)
            {
                GetCart().RemoveItem(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        // This method is responsible for getting the user's cart
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}