using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using ArtShop.Business;
using System.Net;

namespace ArtShop.Services.Http
{
    [RoutePrefix("api/Cart")]
    class CartService : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public Cart Add(Cart cart)
        {
            try
            {
                var bc = new CartBusiness();
                return bc.AgregarCarrito(cart);
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
        public void Edit(Cart cart)
        {
            try
            {
                var bc = new CartBusiness();
                bc.EditarCarrito(cart);
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
        public Cart Find(int id)
        {
            try
            {
                var bc = new CartBusiness();
                return bc.GetCart(id);
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


        [HttpGet]
        [Route("Listar")]
        public List<Cart> List()
        {
            try
            {
                var bc = new CartBusiness();
                return bc.ListarTodosLosCarritos();
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
                var bc = new CartBusiness();
                bc.BorrarCarrito(id);
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
