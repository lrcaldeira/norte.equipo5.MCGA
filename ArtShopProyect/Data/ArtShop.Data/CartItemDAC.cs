using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
    public partial class CartItemDAC : DataAccessComponent
    {
        public CartItem Create(CartItem cartitem)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.CartItem ([Price], [Quantity], [CartId], [ProductId]) " +
                "VALUES(@Price, @Quantity, @CartId, @ProductId); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Price", DbType.String, cartitem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.String, cartitem.Quantity);
                db.AddInParameter(cmd, "@CartId", DbType.String, cartitem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.String, cartitem.ProductId);

                cartitem.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return cartitem;
        }

        public void UpdateById(CartItem cartitem)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.CartItem " +
                "SET " +
                    "[Price]=@Price, " +
                    "[Quantity]=@Quantity, " +
                    "[CartId]=@CartId, " +
                    "[ProductId]=@ProductId, " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Price", DbType.String, cartitem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.String, cartitem.Quantity);
                db.AddInParameter(cmd, "@CartId", DbType.String, cartitem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.String, cartitem.ProductId);
                db.AddInParameter(cmd, "@Id", DbType.Int32, cartitem.Id);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.CartItem " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public CartItem SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Price], [Quantity], [CartId], [ProductId] " +
                "FROM dbo.CartItem  " +
                "WHERE [Id]=@Id ";

            CartItem cartitem = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cartitem = LoadCartItem(dr);
                    }
                }
            }

            return cartitem;
        }


        public List<CartItem> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Price], [Quantity], [CartId], [ProductId] " +
                "FROM dbo.CartItem";

            List<CartItem> result = new List<CartItem>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        CartItem cartitem = LoadCartItem(dr);
                        result.Add(cartitem);
                    }
                }
            }

            return result;
        }


        private CartItem LoadCartItem(IDataReader dr)
        {
            CartItem cartitem = new CartItem();

            cartitem.Id = GetDataValue<int>(dr, "Id");
            cartitem.Price = GetDataValue<double>(dr, "Price");
            cartitem.Quantity = GetDataValue<int>(dr, "Quantity");
            cartitem.CartId = GetDataValue<int>(dr, "CartId");
            cartitem.ProductId = GetDataValue<int>(dr, "ProductId");

            return cartitem;
        }
    }
}
