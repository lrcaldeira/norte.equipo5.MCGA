using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArtShop.UI.Process
{
    public class CartProcess : ProcessComponent
    {
        private CartBusiness biz = new CartBusiness();
        public List<Cart> SelectList()
        {
            var response = HttpGet<List<Cart>>("api/Cart/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public void EditarCarrito(Cart cart)
        {
            HttpPost<Cart>("api/Cart/Editar", cart, MediaType.Json);
        }

        public Cart ArgregarCarrito(Cart cart)
        {
            var response = HttpPost<Cart>("api/Cart/Agregar", cart, MediaType.Json);
            return response;
        }

        public void BorrarCarrito(int id)
        {
            HttpDelete<Cart>("api/Cart/Eliminar", id, MediaType.Json);
        }

        public Cart GetCart(int id)
        {
            var response = HttpGet<Cart>("api/Cart/Buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }
        public List<ValidationResult> ValidateModel(Cart cart)
        {
            return biz.ValidateModel(cart);
        }
    }
}
