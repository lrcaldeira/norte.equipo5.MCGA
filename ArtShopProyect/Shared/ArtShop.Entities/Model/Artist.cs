using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    [Serializable]
    public partial class Artist : IdentityBase
    {
        public Artist()
        {
            this.Product = new HashSet<Product>();
        }
        [DisplayName("Nombre")]
        public string FirstName { get; set; }
        [DisplayName("Apellido")]
        public string LastName { get; set; }
        [DisplayName("Vida")]
        public string LifeSpan { get; set; }
        [DisplayName("País")]
        public string Country { get; set; }
        [DisplayName("Descripción")]
        public string Description { get; set; }
        [DisplayName("Cuadros")]
        public int TotalProducts { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public virtual ICollection<Product> Product { get; set; }
    }
}
