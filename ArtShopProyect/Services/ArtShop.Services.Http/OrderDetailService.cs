using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ArtShop.Business;

namespace ArtShop.Services.Http
{
    [RoutePrefix("api/OrderDetail")]
    public class OrderDetailService : ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public List<OrderDetail> List()
        {
            try
            {
                var bc = new OrderDetailBusiness();
                return bc.ListarOrderDetail();
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Agregar")]
        public OrderDetail Add(OrderDetail item)
        {
            try
            {
                var bc = new OrderDetailBusiness();
                return bc.AgregarOrderDetail(item);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpDelete]
        [Route("Eliminar")]
        public void Remove(int id)
        {
            try
            {
                var bc = new OrderDetailBusiness();
                bc.BorrarOrderDetail(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public OrderDetail Edit(OrderDetail item)
        {
            try
            {
                var bc = new OrderDetailBusiness();
                return bc.EditarOrderDetail(item);
            }
            catch (Exception ex)
            {
                // Repack to Http error.
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("Buscar")]
        public OrderDetail Find(int id)
        {
            try
            {
                var bc = new OrderDetailBusiness();
                return bc.GetOrderDetail(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}