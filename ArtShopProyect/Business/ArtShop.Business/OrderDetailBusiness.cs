using ArtShop.Data;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Business
{
    public class OrderDetailBusiness
    {
        private BaseDataService<OrderDetail> db = new BaseDataService<OrderDetail>();
        public List<OrderDetail> ListarOrderDetail()
        {
            // return db.Get();

            List<OrderDetail> result = default(List<OrderDetail>);
            var orderdetailDAC = new OrderDetailDAC();
            result = orderdetailDAC.Select();
            return result;
        }

        public OrderDetail EditarOrderDetail (OrderDetail orderdetail)
        {
            var orderdetailDAC = new OrderDetailDAC();
            return orderdetailDAC.UpdateById(orderdetail);
        }

        public OrderDetail AgregarOrderDetail(OrderDetail orderdetail)
        {
            //return db.Create(orderdetail);
            OrderDetail result = default(OrderDetail);
            var orderdetailDAC = new OrderDetailDAC();
            result = orderdetailDAC.Create(orderdetail);
            return result;
        }

        public void BorrarOrderDetail(int id)
        {
            var orderdetailDAC = new OrderDetailDAC();
            orderdetailDAC.DeleteById(id);
            //db.Delete(id);
        }

        public OrderDetail GetOrderDetail(int id)
        {
            //return db.GetById(id);
            var orderdetailDAC = new OrderDetailDAC();
            var result = orderdetailDAC.SelectById(id);
            return result;
        }

        public List<ValidationResult> ValidateModel(OrderDetail orderdetail)
        {
            return db.ValidateModel(orderdetail);
        }
    }
}
