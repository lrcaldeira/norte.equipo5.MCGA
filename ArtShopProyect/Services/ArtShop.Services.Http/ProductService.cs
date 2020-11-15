﻿using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ArtShop.Services.Http
{
   [RoutePrefix("api/Product")]
   public class ProductService
    {

      [HttpPost]
      [Route ("Agregar")]

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
        public void Edit(Product product)
        {
            try
            {
                var bc = new ProductBusiness();
                bc.Edit(product);
               
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



        //[HttpGet]
        //[Route("Buscar")]
        //public Product Find(int id)
        //{
        //    try
        //    {
        //        var bc = new ProductBusiness();
        //        return bc.GetProduct(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        var httpError = new HttpResponseMessage()
        //        {
        //            StatusCode = (HttpStatusCode)422,
        //            ReasonPhrase = ex.Message
        //        };

        //        throw new HttpResponseException(httpError);
        //    }
        //}


        //[HttpGet]
        //[Route("Listar")]
        //public List<Product> List()
        //{
        //    try
        //    {
        //        var bc = new ProductBusiness();
        //        return bc.GetProduct(Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        var httpError = new HttpResponseMessage()
        //        {
        //            StatusCode = (HttpStatusCode)422,
        //            ReasonPhrase = ex.Message
        //        };

        //        throw new HttpResponseException(httpError);
        //    }
        //}
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