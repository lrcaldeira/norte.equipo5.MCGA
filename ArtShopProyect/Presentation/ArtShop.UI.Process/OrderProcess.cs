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
    public class OrderProcess:ProcessComponent
    {
        private OrderBusiness biz = new OrderBusiness();
        public List<Order> ListarOrden()
        {
            var response = HttpGet<List<Order>>("api/Order/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public Order EditarOrden(Order order)
        {
            var response = HttpPut<Order>("api/Order/Editar", order, MediaType.Json);
            return response;
        }

        public Order AgregarOrden(Order order)
        {
            var response = HttpPost<Order>("api/Order/Agregar", order, MediaType.Json);
            return response;
        }

        public void BorrarOrden(int id)
        {
            HttpDelete<Order>("api/Order/Eliminar?id=" + id, MediaType.Json);
        }

        public Order GetOrder(int id)
        {
            var response = HttpGet<Order>("api/Order/Buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }
        public List<ValidationResult> ValidateModel(Order order)
        {
            return biz.ValidateModel(order);
        }
    }
}
