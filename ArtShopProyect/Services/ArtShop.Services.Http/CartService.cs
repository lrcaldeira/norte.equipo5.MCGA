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
    [RoutePrefix("api/Cart")]
    public class CartService : ApiController
    {
        [HttpPost]
        [Route("Agregar")]
        public Cart Add(Cart cart)
        {
            try
            {
                var bc = new CartBusiness();
                return bc.CrearCarrito(cart);
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
