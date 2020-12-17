using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ArtShop.Entities.Model
{
    [DataContract]
    [Serializable]
    public partial class Artist : IdentityBase
    {
        public Artist()
        {
            this.Product = new HashSet<Product>();
        }
        [DisplayName("Nombre")]
        [DataMember]
        public string FirstName { get; set; }

        [DisplayName("Apellido")]
        [DataMember]
        public string LastName { get; set; }

        [DisplayName("Vida")]
        [DataMember]
        public string LifeSpan { get; set; }

        [DisplayName("País")]
        [DataMember]
        public string Country { get; set; }

        [DisplayName("Descripción")]
        [DataMember]
        public string Description { get; set; }

        [DisplayName("Cuadros")]
        [DataMember]
        public int TotalProducts { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
