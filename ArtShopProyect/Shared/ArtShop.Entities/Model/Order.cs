using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ArtShop.Entities.Model
{

    [Serializable]

    public partial class Order : IdentityBase
    {
        [DataMember]
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public int OrderNumber { get; set; }

        public int ItemCount { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        public string Fecha { get; set; }
    }
}
