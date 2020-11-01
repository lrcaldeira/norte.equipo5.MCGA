using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class ArtistBusiness
    {
        private BaseDataService<Artist> db = new BaseDataService<Artist>();
        public List<Artist> ListarTodosLosArtistas()
        {
            // return db.Get();

            List<Artist> result = default(List<Artist>);
            var artistDAC = new ArtistDAC();
            result = artistDAC.Select();
            return result;
        }

        public void EditarArtista(Artist artist)
        {
            var artistDAC = new ArtistDAC();
            artistDAC.UpdateById(artist);
        }

        public Artist AgregarArtista(Artist artist)
        {
            //return db.Create(artist);
            Artist result = default(Artist);
            var artistDAC = new ArtistDAC();
            result = artistDAC.Create(artist);
            return result;
        }

        public void BorrarArtista(int id)
        {
            var artistDAC = new ArtistDAC();
            artistDAC.DeleteById(id);
            //db.Delete(id);
        }

        public Artist GetArtist(int id)
        {
            //return db.GetById(id);
            var artistDAC = new ArtistDAC();
            var result = artistDAC.SelectById(id);
            return result;
        }

        public List<ValidationResult> ValidateModel(Artist artist)
        {
            return db.ValidateModel(artist);
        }
    }

}
