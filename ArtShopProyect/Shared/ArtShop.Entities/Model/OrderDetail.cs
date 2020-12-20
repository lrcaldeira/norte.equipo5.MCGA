using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ArtShop.Entities.Model
{
    [Serializable]
    public class OrderDetail : IdentityBase
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        public string Titulo { get; set; }
    }
}
