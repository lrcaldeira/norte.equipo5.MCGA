using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    [Serializable]
    [DataContract]
    public partial class Cart:IdentityBase
    {
        
        public Cart()
        {
            this.CartItem = new HashSet<CartItem>();
        }

        [DataMember]
        public string Cookie { get; set; }
        [DataMember]
        public DateTime CartDate { get; set; }
        [DataMember]
        public int ItemCount { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }

    }
}
