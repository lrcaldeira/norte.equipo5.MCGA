using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model

{
    [Serializable]
    public class CartItem : IdentityBase
    {
        [DataMember]
        public int CartId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public Product _Product { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}