using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArtShop.Services.Http
{
    [RoutePrefix("api/Product")]
    public class ProductService : ApiController
    {

        [HttpPost]
        [Route("Agregar")]
        public Product Add(Product product)
        {
            try
            {
                var bc = new ProductBusiness();
                return bc.Create(product);
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
        public Product Edit(Product product)
        {
            try
            {
                var bc = new ProductBusiness();
                return bc.Edit(product);

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
        public Product Find(int id)
        {
            try
            {
                var bc = new ProductBusiness();
                return bc.GetProduct(id);
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
        public List<Product> List()
        {
            try
            {
                var bc = new ProductBusiness();
                return bc.ListarTodosLosProductos();
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
        public void Delete(int id)
        {
            try
            {
                var bc = new ProductBusiness();
                bc.Delete(id);
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
