using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
  public partial class ProductDAC : DataAccessComponent
    {
        public Product Create(Product product)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Product ([Title], [Description], [Image], [Price], [QuantitySold], [AvgStars], [ArtistId], [CreatedOn], [ChangedOn], [CreatedBy], [ChangedBy]) " +
                "VALUES(@Title, @Description, @Image, @Price, @QuantitySold, @AvgStars, @ArtistId, @CreatedOn, @ChangedOn, @CreatedBy, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, product.Description);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.String, product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.String, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Int32, product.AvgStars);
                db.AddInParameter(cmd, "@ArtistId", DbType.Int32, product.Artist.Id);

                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, product.CreatedOn != DateTime.MinValue ? product.CreatedOn : DateTime.Now);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, product.ChangedOn != DateTime.MinValue ? product.ChangedOn : DateTime.Now);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, String.IsNullOrEmpty(product.CreatedBy) ? "Admin" : product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, String.IsNullOrEmpty(product.ChangedBy) ? "Admin" : product.ChangedBy);

                product.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return product;
        }

        public Product UpdateById(Product product)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Product " +
                "SET " +
                    "[Title] = @Title, " +
                    "[Description] = @Description, " +
                    "[Image] = @Image, " +
                    "[Price] = @Price, " +
                    "[ArtistId] = @ArtistId, " +
                    "[QuantitySold] = @QuantitySold "+
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, product.Description);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.String, product.Price);
                db.AddInParameter(cmd, "@ArtistId", DbType.String, product.Artist.Id);
                db.AddInParameter(cmd, "@QuantitySold", DbType.String, product.QuantitySold);
                db.AddInParameter(cmd, "@Id", DbType.Int32, product.Id);

                db.AddInParameter(cmd, "@ChangedBy", DbType.String, String.IsNullOrEmpty(product.ChangedBy) ? "Admin" : product.ChangedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, product.ChangedOn != DateTime.MinValue ? product.ChangedOn : DateTime.Now);
                db.ExecuteNonQuery(cmd);
            }

            return product;
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
                "SELECT Product.Id, [Title], Product.Description, [Image], [Price], [ArtistId], [FirstName], [LastName], QuantitySold " +
                "FROM dbo.Product, dbo.Artist " +
                "WHERE Product.ArtistId = Artist.Id AND Product.Id = @Id ";

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
                "SELECT Product.Id,Title, Product.Description, QuantitySold, Image, Price, ArtistId , FirstName, LastName " +
                "FROM dbo.Product,dbo.Artist where Product.ArtistId=Artist.Id Order By Product.Id asc";

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
            product.Description = GetDataValue<string>(dr, "Description");
            product.QuantitySold = GetDataValue<int>(dr, "QuantitySold");
            product.Image = GetDataValue<string>(dr, "Image");
            product.Price = GetDataValue<double>(dr, "Price");
            product.Artist.Id = GetDataValue<int>(dr, "ArtistId");
            product.Artist.FirstName = GetDataValue<string>(dr, "FirstName");
            product.Artist.LastName = GetDataValue<string>(dr, "LastName");

            return product;
        }
    }
}

