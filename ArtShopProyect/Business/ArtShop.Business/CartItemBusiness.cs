using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ArtShop.Entities;


namespace ArtShop.Business
{
    public class CartItemBusiness
    {
        private BaseDataService<CartItem> db = new BaseDataService<CartItem>();
        public List<CartItem> ListarTodosLosItems()
        {
            // return db.Get();

            List<CartItem> result = default(List<CartItem>);
            var cartitemDAC = new CartItemDAC();
            result = cartitemDAC.Select();
            return result;
        }

        public void EditarCartItem(CartItem cartitem)
        {
            var cartitemDAC = new CartItemDAC();
            cartitemDAC.UpdateById(cartitem);
        }

        public CartItem AgregarCartItem(CartItem cartitem)
        {
            //return db.Create(cartitem);
            CartItem result = default(CartItem);
            var cartitemDAC = new CartItemDAC();
            result = cartitemDAC.Create(cartitem);
            return result;
        }

        public void BorrarCartItem(int id)
        {
            var cartitemDAC = new CartItemDAC();
            cartitemDAC.DeleteById(id);
            //db.Delete(id);
        }

        public CartItem GetCartItem(int id)
        {
            //return db.GetById(id);
            var cartitemDAC = new CartItemDAC();
            var result = cartitemDAC.SelectById(id);
            return result;
        }

        public List<ValidationResult> ValidateModel(CartItem cartitem)
        {
            return db.ValidateModel(cartitem);
        }
    }
}
