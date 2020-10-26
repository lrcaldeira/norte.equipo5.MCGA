using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data
{
  public class ProductDAC: DataAccessComponent
    {
        public Product Create(Product product)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Product ([Title], [Descripcion], [Image], [Price], [QuantitySold], [AvgStars], [ArtistId]) " +
                "VALUES(@Title, @Descripcion, @Image, @Price, @QuantitySold, @AvgStars, @ArtistId); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, product.Description);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.String, product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.String, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Int32, product.AvgStars);
                db.AddInParameter(cmd, "@ArtistId", DbType.Int32, product.ArtistId);

               product.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return product;
        }

        public void UpdateById(Product product)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Artist " +
                "SET " +
                    "[Title]=@Title, " +
                    "[Descripcion]=@Descripcion, " +
                    "[Image]=@Image, " +
                    "[Price]= @Price, " +
                    "[QuantitySold]=@QuantitySold, " +
                    "[AvgStars]=@AvgStars  " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Descripcion", DbType.String, product.Description);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.String, product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.String, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Int32, product.AvgStars);
                db.AddInParameter(cmd, "@Id", DbType.Int32, product.Id);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Product " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Product SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Title], [Descripcion], [Image], [Price], [QuantitySold], [AvgStars], [ArtistId] " +
                "FROM dbo.Product  " +
                "WHERE [Id]=@Id ";

            Product product = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        product = LoadProduct(dr);
                    }
                }
            }

            return product;
        }


        public List<Product> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Title], [Descripcion], [Image], [Price], [QuantitySold], [AvgStars], [ArtistId] " +
                "FROM dbo.Product ";

            List<Product> result = new List<Product>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Product product = LoadProduct(dr);
                        result.Add(product);
                    }
                }
            }

            return result;
        }


        private Product LoadProduct(IDataReader dr)
        {
            Product product = new Product();

            product.Id = GetDataValue<int>(dr, "Id");
            product.Title = GetDataValue<string>(dr, "Title");
            product.Description = GetDataValue<string>(dr, "Descripcion");
            product.Image = GetDataValue<string>(dr, "Image");
            product.Price = GetDataValue<double>(dr, "Price");
            product.QuantitySold = GetDataValue<int>(dr, "QuantitySold");
            product.AvgStars = GetDataValue<int>(dr, "AvgStars");

            return product;
        }
    }
}

