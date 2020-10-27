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
    public class ProductBusiness
    {
        private BaseDataService<Product> db = new BaseDataService<Product>();
        public List<Product> ListarTodosLosProductos()
        {
            List<Product> result = default(List<Product>);
            var productDAC = new ProductDAC();
            result = productDAC.Select();
            return result;
        }

        public void Edit(Product product)
        {
            var productDAC = new ProductDAC();
            productDAC.UpdateById(product);
        }

        public Product Create(Product product)
        {
            Product result = default(Product);
            var productDAC = new ProductDAC();
            result = productDAC.Create(product);
            return result;
        }

        public void Delete(int id)
        {
            var productDAC = new ProductDAC();
            productDAC.DeleteById(id);
           
        }

        public Product GetProduct(int id)
        {
            var productDAC = new ProductDAC();
            var result = productDAC.SelectById(id);
            return result;
        }


        public List<ValidationResult> ValidateModel(Product product)
        {
            return db.ValidateModel(product);
        }
    }
}