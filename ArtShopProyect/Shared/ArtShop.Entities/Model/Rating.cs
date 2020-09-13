using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace ArtShop.Entities.Model
{
    [Serializable]
    public partial class Rating : IdentityBase
    {
        public int Stars { get; set; }

        public string UserName { get; set; }

        public virtual Product Product { get; set; }
    }
}
