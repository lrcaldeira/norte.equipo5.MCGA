using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using ArtShop.Business;
using System.Net;

namespace ArtShop.Services.Http
{
    [RoutePrefix("api/CartItem")]
    class CartItemService : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public CartItem Add(CartItem cartitem)
        {
            try
            {
                var bc = new CartItemBusiness();
                return bc.AgregarCartItem(cartitem);
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
        public void Edit(CartItem cartitem)
        {
            try
            {
                var bc = new CartItemBusiness();
                bc.EditarCartItem(cartitem);
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
        public CartItem Find(int id)
        {
            try
            {
                var bc = new CartItemBusiness();
                return bc.GetCartItem(id);
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
        public List<CartItem> List()
        {
            try
            {
                var bc = new CartItemBusiness();
                return bc.ListarTodosLosItems();
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
                var bc = new CartItemBusiness();
                bc.BorrarCartItem(id);
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
