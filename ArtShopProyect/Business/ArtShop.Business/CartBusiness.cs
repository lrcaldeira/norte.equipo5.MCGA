using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class CartBusiness
    {
        private BaseDataService<Cart> db = new BaseDataService<Cart>();
        public List<Cart> ListarTodosLosCarritos()
        {
            // return db.Get();

            List<Cart> result = default(List<Cart>);
            var cartDAC = new CartDAC();
            result = cartDAC.Select();
            return result;
        }

        public void EditarCarrito(Cart cart)
        {
            var cartDAC = new CartDAC();
            cartDAC.UpdateById(cart);
        }

        public Cart AgregarCarrito(Cart cart)
        {
            //return db.Create(cart);
            Cart result = default(Cart);
            result = new CartDAC().Create(cart);
            return result;
        }

        public void BorrarCarrito(int id)
        {
            var cartDAC = new CartDAC();
            cartDAC.DeleteById(id);
            //db.Delete(id);
        }

        public Cart GetCart(int id)
        {
            //return db.GetById(id);
            var cartDAC = new CartDAC();
            var result = cartDAC.SelectById(id);
            return result;
        }

        public List<ValidationResult> ValidateModel(Cart cart)
        {
            return db.ValidateModel(cart);
        }
    }
}
