using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ArtShop.Entities.Model
{
    [Serializable]
    [DataContract]
    public partial class Product : IdentityBase
    {
        public Product()
        {
            this.CartItem = new HashSet<CartItem>();
            this.OrderDetail = new HashSet<OrderDetail>();
            this.Rating = new HashSet<Rating>();
        }

        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int QuantitySold { get; set; }
        [DataMember]
        public double AvgStars { get; set; }
        [DataMember]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }


    }
}
