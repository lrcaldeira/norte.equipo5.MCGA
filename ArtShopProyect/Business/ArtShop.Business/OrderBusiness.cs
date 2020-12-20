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
    public class OrderBusiness
    {
        private BaseDataService<Order> db = new BaseDataService<Order>();
        public List<Order> ListarTodasLasOrdenes()
        {
            // return db.Get();

            List<Order> result = default(List<Order>);
            var orderDAC = new OrderDAC();
            result = orderDAC.Select();
            return result;
        }

        public Order EditarOrder(Order order)
        {
            var orderDAC = new OrderDAC();
            return orderDAC.UpdateById(order);
        }

        public Order AgregarOrder(Order order)
        {
            //return db.Create(order);
            Order result = default(Order);
            var orderDAC = new OrderDAC();
            result = orderDAC.Create(order);
            return result;
        }

        public void BorrarOrder(int id)
        {
            var orderDAC = new OrderDAC();
            orderDAC.DeleteById(id);
            //db.Delete(id);
        }

        public Order GetOrder(int id)
        {
            //return db.GetById(id);
            var orderDAC = new OrderDAC();
            var result = orderDAC.SelectById(id);
            return result;
        }

        public List<ValidationResult> ValidateModel(Order order)
        {
            return db.ValidateModel(order);
        }

    }
}