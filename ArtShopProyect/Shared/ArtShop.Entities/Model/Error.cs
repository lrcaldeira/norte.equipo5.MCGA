using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Entities.Model
{
    [Serializable]
    public partial class Error : IdentityBase
    {
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Error Date")]
        public DateTime? ErrorDate { get; set; }

        [DisplayName("Ip Address")]
        public string IpAddress { get; set; }

        [DisplayName("User Agent")]
        public string UserAgent { get; set; }

        [DisplayName("Exception")]
        public string Exception { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

        [DisplayName("Everything")]
        public string Everything { get; set; }

        [DisplayName("Http Referer")]
        public string HttpReferer { get; set; }

        [DisplayName("Path And Query")]
        public string PathAndQuery { get; set; }


    }
}
