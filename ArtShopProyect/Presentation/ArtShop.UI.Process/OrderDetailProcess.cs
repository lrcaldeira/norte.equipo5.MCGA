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
    public class OrderDetailProcess: ProcessComponent
    {
        private OrderDetailBusiness biz = new OrderDetailBusiness();
        public List<OrderDetail> ListarDetalleOrden()
        {
            var response = HttpGet<List<OrderDetail>>("api/OrderDetail/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        public OrderDetail EditarDetalleOrden(OrderDetail orderdetail)
        {
            var response = HttpPut<OrderDetail>("api/OrderDetail/Editar", orderdetail, MediaType.Json);
            return response;
        }

        public OrderDetail AgregarDetalleOrden(OrderDetail orderdetail)
        {
            var response = HttpPost<OrderDetail>("api/OrderDetail/Agregar", orderdetail, MediaType.Json);
            return response;
        }

        public void BorrarDetalleOrden(int id)
        {
            HttpDelete<OrderDetail>("api/OrderDetail/Eliminar?id=" + id, MediaType.Json);
        }

        public OrderDetail GetOrderDetail(int id)
        {
            var response = HttpGet<OrderDetail>("api/OrderDetail/Buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }
        public List<ValidationResult> ValidateModel(OrderDetail orderdetail)
        {
            return biz.ValidateModel(orderdetail);
        }
    }
}
