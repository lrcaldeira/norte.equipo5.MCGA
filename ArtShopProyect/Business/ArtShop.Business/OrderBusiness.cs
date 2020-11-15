using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class OrderBusiness
    {
        private BaseDataService<Order> db = new BaseDataService<Order>();

        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        OrderDAC orderdac = new OrderDAC();
        OrderNumberDAC Ordernumber = new OrderNumberDAC();
        OrderDetailDAC orderdetail = new OrderDetailDAC();


    }
}