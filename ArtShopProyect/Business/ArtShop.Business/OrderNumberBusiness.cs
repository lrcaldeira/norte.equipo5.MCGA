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
    public class OrderNumberBusiness
    {
        private BaseDataService<OrderNumber> db = new BaseDataService<OrderNumber>();
        public List<OrderNumber> ListarOrderNumbers()
        {
            // return db.Get();

            List<OrderNumber> result = default(List<OrderNumber>);
            var ordernumberDAC = new OrderNumberDAC();
            result = ordernumberDAC.Select();
            return result;
        }

        public void EditarOrderNumber(OrderNumber ordernumber)
        {
            var ordernumberDAC = new OrderNumberDAC();
            ordernumberDAC.UpdateById(ordernumber);
        }

        public OrderNumber AgregarOrderNumber(OrderNumber ordernumber)
        {
            //return db.Create(ordernumber);
            OrderNumber result = default(OrderNumber);
            var ordernumberDAC = new OrderNumberDAC();
            result = ordernumberDAC.Create(ordernumber);
            return result;
        }

        public void BorrarOrderNumber(int id)
        {
            var ordernumberDAC = new OrderNumberDAC();
            ordernumberDAC.DeleteById(id);
            //db.Delete(id);
        }

        public OrderNumber GetOrderNumber(int id)
        {
            //return db.GetById(id);
            var ordernumberDAC = new OrderNumberDAC();
            var result = ordernumberDAC.SelectById(id);
            return result;
        }

        public List<ValidationResult> ValidateModel(OrderNumber ordernumber)
        {
            return db.ValidateModel(ordernumber);
        }
    }
}
