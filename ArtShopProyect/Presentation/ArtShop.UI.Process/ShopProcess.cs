using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class ShopProcess
    {
        private ShopBusiness shopBusiness = new ShopBusiness();

        public CartItem GetCartItem(int id)
        {
            return shopBusiness.GetCartItem(id);
        }

        public CartItem UpdateCartItem(CartItem cartItem)
        {
            return shopBusiness.UpdateCartItem(cartItem);
        }

        public void DeleteCartItem (CartItem cartItem)
        {
            shopBusiness.RemoveCartItem(cartItem);
        }
    }
}
