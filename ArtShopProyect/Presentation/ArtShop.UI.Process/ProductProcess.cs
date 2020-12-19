using ArtShop.Business;
using ArtShop.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.UI.Process
{
    public class ProductProcess : ProcessComponent
    {

        private ProductBusiness biz = new ProductBusiness();
        public List<Product> ListarTodosLosProductos()
        {
            var response = HttpGet<List<Product>>("api/Product/Listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Product EditarProducto(Product product)
        {
            var response = HttpPut<Product>("api/Product/Editar", product, MediaType.Json);
            return response;
        }

        public Product AgregarProducto(Product product)
        {
            var response = HttpPost<Product>("api/Product/Agregar", product, MediaType.Json);
            return response;
        }

        public void BorrarProducto(int id)
        {
            HttpDelete<Product>("api/Product/Eliminar?id=" + id, MediaType.Json);
        }

        public List<ValidationResult> ValidateModel(Product product)
        {
            return biz.ValidateModel(product);
        }

        public Product BuscarProductoPorId(int Id)
        {
            var response = HttpGet<Product>("api/Product/Buscar", new Dictionary<string, object> { { "Id", Id } }, MediaType.Json);
            return response;
        }

    }
}