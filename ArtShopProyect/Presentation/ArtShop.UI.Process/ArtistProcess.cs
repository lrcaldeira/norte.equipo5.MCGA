﻿using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class ArtistProcess : ProcessComponent
    {
        private ArtistBusiness biz = new ArtistBusiness();
        public List<Artist> ListarTodosLosArtistas()
        {
            var response = HttpGet<List<Artist>>("api/Artist/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Artist EditarArtista(Artist artist)
        {
            var response = HttpPut<Artist>("api/Artist/Editar", artist, MediaType.Json);
            return response;
        }

        public Artist ArgregarArtista(Artist artist)
        {
            var response = HttpPost<Artist>("api/Artist/Agregar", artist, MediaType.Json);
            return response;
        }

        public void BorrarArtista(int id)
        {
            HttpDelete<Artist>("api/Artist/Eliminar?id=" + id, MediaType.Json);
        }

        public Artist GetArtist(int id)
        {
            var response = HttpGet<Artist>("api/Artist/Buscar", new Dictionary<string, object> { { "Id", id } }, MediaType.Json);
            return response;
        }
        public List<ValidationResult> ValidateModel(Artist artist)
        {
            return biz.ValidateModel(artist);
        }

    }
}
