using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
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
            return db.Get();
        }

        public Artist EditarArtista(Artist artist)
        {
            return db.Update(artist, artist.Id);
        }
    }
}