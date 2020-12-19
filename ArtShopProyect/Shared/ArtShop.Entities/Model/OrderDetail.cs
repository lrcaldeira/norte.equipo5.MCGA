using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ArtShop.Entities.Model
{
    [Serializable]
    public partial class OrderDetail : IdentityBase
    {

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public string Titulo { get; set; }
    }
}
