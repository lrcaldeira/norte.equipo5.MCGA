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
        CartDAC cartdac = new CartDAC();

        public Cart CrearCarrito(Cart cart)
        {

            //Cart update = cart.Id > 0 ? cartdac.SelectById(cart.Id) : new Cart { CreatedOn = DateTime.Now };

            //update.CartDate = cart.CartDate == null ? throw new BusinessException("b.validation.cart.cartdate.invalid") : cart.CartDate;
            //update.Cookie = string.IsNullOrEmpty(cart.Cookie) ? throw new BusinessException("b.validation.cart.cookie.invalid") : cart.Cookie;
            //update.ChangedOn = DateTime.Now;
            //update.ChangedBy = cart.ChangedBy;
            //var saved = cartdac.Create(cart);
            //return saved;

            cart.ChangedOn = DateTime.Now;
            cart.ChangedBy = "nico";
            cart.CreatedOn = DateTime.Now;
            cart.CreatedBy = "nico";

            Cart result = default(Cart);
            CartDAC cartdac = new CartDAC();
            result = cartdac.Create(cart);
            return result;
        }

        public void Borrar(int id)
        {
            cartdac.DeleteById(id);
        }

        public List<Cart> Listar()
        {
            var result = cartdac.Select();
            return result;
        }

        public Cart Buscar(int id)
        {
            return cartdac.SelectById(id);
        }

        public Cart Edit(Cart cart)
        {
            return db.Update(cart, cart.Id);
        }

        public List<ValidationResult> ValidateModel(Cart cart)
        {
            return db.ValidateModel(cart);
        }
    }
}
