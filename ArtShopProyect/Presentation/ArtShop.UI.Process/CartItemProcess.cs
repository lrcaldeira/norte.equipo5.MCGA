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
    public class CartItemItemProcess:ProcessComponent
    {
       
        public List<CartItem> ListarItemsCarritos()
        {
            var response = HttpGet<List<CartItem>>("api/CartItem/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public CartItem EditarItemCarrito(CartItem cartitem)
        {
            var response = HttpPut<CartItem>("api/CartItem/Editar", cartitem, MediaType.Json);
            return response;
        }

        public CartItem AgregarItemCarrito(CartItem cartitem)
        {
            var response = HttpPost<CartItem>("api/CartItem/Agregar", cartitem, MediaType.Json);
            return response;
        }

        public void EliminarItemCarrito(int id)
        {
            HttpDelete<CartItem>("api/CartItem/Eliminar?id=" + id, MediaType.Json);
        }

        public CartItem ListarUno(int Id)
        {
            var response = HttpGet<CartItem>("api/CartItem/Buscar", new Dictionary<string, object> { { "Id", Id } }, MediaType.Json);
            return response;
        }
        public CartItem GetCartItem(int id)
        {
            var response = HttpGet<CartItem>("api/CartItem/Buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }
    }
}
