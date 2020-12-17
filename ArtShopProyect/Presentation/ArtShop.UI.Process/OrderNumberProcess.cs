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
    public class OrderNumberProcess:ProcessComponent
    {
        private OrderNumberBusiness biz = new OrderNumberBusiness();
        public List<OrderNumber> ListarNroOrden()
        {
            var response = HttpGet<List<OrderNumber>>("api/OrderNumber/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public OrderNumber EditarNroOrden(OrderNumber ordernumber)
        {
            var response = HttpPut<OrderNumber>("api/OrderNumber/Editar", ordernumber, MediaType.Json);
            return response;
        }

        public OrderNumber AgregarNroOrden(OrderNumber ordernumber)
        {
            var response = HttpPost<OrderNumber>("api/OrderNumber/Agregar", ordernumber, MediaType.Json);
            return response;
        }

        public void BorrarNroOrden(int id)
        {
            HttpDelete<OrderNumber>("api/OrderNumber/Eliminar?id=" + id, MediaType.Json);
        }

        public OrderNumber GetOrderNumber(int id)
        {
            var response = HttpGet<OrderNumber>("api/OrderNumber/Buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }
        public List<ValidationResult> ValidateModel(OrderNumber ordernumber)
        {
            return biz.ValidateModel(ordernumber);
        }

    }
}
