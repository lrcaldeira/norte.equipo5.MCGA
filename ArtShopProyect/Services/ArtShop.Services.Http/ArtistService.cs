﻿using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using ArtShop.Business;
using System.Net;

namespace ArtShop.Services.Http
{
    [RoutePrefix("api/Artist")]
    public class ArtistService : ApiController
    {

        [HttpPost]
        [Route("Agregar")]
        public Artist Add(Artist artist)
        {
            try
            {
                var bc = new ArtistBusiness();
                return bc.AgregarArtista(artist);
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
        public void Edit(Artist artist)
        {
            try
            {
                var bc = new ArtistBusiness();
                bc.EditarArtista(artist);
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
        public Artist Find(int id)
        {
            try
            {
                var bc = new ArtistBusiness();
                return bc.GetArtist(id);
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
        public List<Artist> List()
        {
            try
            {
                var bc = new ArtistBusiness();
                return bc.ListarTodosLosArtistas();
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
                var bc = new ArtistBusiness();
                bc.BorrarArtista(id);
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
