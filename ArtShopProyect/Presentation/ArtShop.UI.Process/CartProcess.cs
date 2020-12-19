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
        public List<Cart> ListarCarrito()
        {
            var response = HttpGet<List<Cart>>("api/Cart/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public Cart EditarCarrito(Cart cart)
        {
            var response = HttpPut<Cart>("api/Cart/Editar", cart, MediaType.Json);
            return response;
        }

        public Cart AgregarCarrito(Cart cart)
        {
            var response = HttpPost<Cart>("api/Cart/Agregar", cart, MediaType.Json);
            return response;
        }

        public void BorrarCarrito(int id)
        {
            HttpDelete<Cart>("api/Cart/Eliminar?id="+ id, MediaType.Json);
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

        public Cart ListarUno(int Id)
        {
            var response = HttpGet<Cart>("api/Cart/Buscar", new Dictionary<string, object> { { "Id", Id } }, MediaType.Json);
            return response;
        }
    }
}
