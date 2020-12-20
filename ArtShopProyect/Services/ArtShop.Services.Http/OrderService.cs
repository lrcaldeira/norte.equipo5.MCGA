using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ArtShop.Business;
using ArtShop.Entities.Model;
using System.Net;
using System.Net.Http;

namespace ArtShop.Services.Http
{
    [RoutePrefix("api/Order")]
    public class OrderService : ApiController
    {
        [HttpGet]
        [Route("Listar")]
        public List<Order> List()
        {
            try
            {
                var bc = new OrderBusiness();
                return bc.ListarTodasLasOrdenes();
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
        public Order Add(Order order)
        {
            try
            {
                var bc = new OrderBusiness();
                return bc.AgregarOrder(order);
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
                var bc = new OrderBusiness();
                bc.BorrarOrder(id);
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
        public Order Edit(Order order)
        {
            try
            {
                var bc = new OrderBusiness();
                return bc.EditarOrder(order);
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
        public Order Find(int id)
        {
            try
            {
                var bc = new OrderBusiness();
                return bc.GetOrder(id);
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