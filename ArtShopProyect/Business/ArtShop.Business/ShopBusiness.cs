using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class ShopBusiness
    {
        private BaseDataService<CartItem> db = new BaseDataService<CartItem>();
        public CartItem GetCartItem(int id)
        {
            return db.GetById(id);
        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            return db.Update(cartItem, cartItem.Id);
        }

        public void RemoveCartItem(CartItem cartItem)
        {
            db.Delete(cartItem);
        }
    }
}
