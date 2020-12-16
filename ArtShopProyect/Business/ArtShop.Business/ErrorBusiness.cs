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
    public class ErrorBusiness
    {
        private BaseDataService<Error> db = new BaseDataService<Error>();
        public List<Error> ListarTodosLosErrores()
        {
            // return db.Get();

            List<Error> result = default(List<Error>);
            var errorDAC = new ErrorDAC();
            result = errorDAC.Select();
            return result;
        }

        public void EditarErrora(Error error)
        {
            var errorDAC = new ErrorDAC();
            errorDAC.UpdateById(error);
        }

        public Error AgregarErrora(Error error)
        {
            //return db.Create(error);
            Error result = default(Error);
            var errorDAC = new ErrorDAC();
            result = errorDAC.Create(error);
            return result;
        }

        public void BorrarErrora(int id)
        {
            var errorDAC = new ErrorDAC();
            errorDAC.DeleteById(id);
            //db.Delete(id);
        }

        public Error GetError(int id)
        {
            //return db.GetById(id);
            var errorDAC = new ErrorDAC();
            var result = errorDAC.SelectById(id);
            return result;
        }

        public List<ValidationResult> ValidateModel(Error error)
        {
            return db.ValidateModel(error);
        }
    }
}
