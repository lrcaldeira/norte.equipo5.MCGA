using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
   public class User
    {
        public System.Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public System.DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }


    }
}