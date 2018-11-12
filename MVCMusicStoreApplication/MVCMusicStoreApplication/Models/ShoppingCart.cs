using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class ShoppingCart
    {
        private string ShoppingCartID;
        private string CartSessionKey = "CartID";

        MVCMusicStoreApplicationDB db = new MVCMusicStoreApplicationDB();

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartID = cart.GetCartId(context);
            return cart;
        }

        public string GetCartId(HttpContextBase context)
        {
            string cartId;
            if (context.Session[CartSessionKey]==null)
            {
                // Create a cart id and add it to the session variable
                cartId = Guid.NewGuid().ToString();
                context.Session[CartSessionKey] = cartId;
            }
            else
            {
                cartId = context.Session[CartSessionKey].ToString();
                // retrieve cart id
            }
            return cartId;
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart => cart.CartID == ShoppingCartID).ToList();
        }

        public decimal GetCartTotal()
        {
            decimal? total = (from cartItems in db.Carts
                             where cartItems.CartID == ShoppingCartID
                             select cartItems.AlbumSelected.Price * (int?) cartItems.Count).Sum();

            return total ?? decimal.Zero;
        }

        public void AddtoCart(int id)
        {

            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartID == ShoppingCartID && c.AlbumId == id);

            // CartItem does not exist in db => add CartItem to database
            if (cartItem == null)
            {
                Album album = db.Albums.SingleOrDefault(a => a.AlbumId == id);
                cartItem = new Cart()
                {
                    CartID = ShoppingCartID,
                    AlbumId = id,
                    AlbumSelected = album,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.Carts.Add(cartItem);
            }
            else
            {
                // CartItem exists already in db => Update count
                cartItem.Count++;
            }
            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            Cart cartItem = db.Carts.SingleOrDefault(cart => cart.RecordId == id);
            int count = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    count = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                    count = 0;
                }

                db.SaveChanges();
            }

            return count;
        }
    }
}