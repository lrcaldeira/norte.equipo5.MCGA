using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
    public partial class CartDAC : DataAccessComponent
    {
        public Cart Create(Cart cart)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Cart ([Cookie], [CartDate], [CartItem], [ItemCount]) " +
                "VALUES(@Cookie, @CartDate, @ItemCount); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Cookie", DbType.String, cart.Cookie);
                db.AddInParameter(cmd, "@CartDate", DbType.String, cart.CartDate);
                db.AddInParameter(cmd, "@ItemCount", DbType.String, cart.ItemCount);

                cart.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return cart;
        }

        public void UpdateById(Cart cart)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Cart " +
                "SET " +
                    "[Cookie]=@Cookie, " +
                    "[CartDate]=@CartDate, " +
                    "[ItemCount]=@ItemCount, " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Cookie", DbType.String, cart.Cookie);
                db.AddInParameter(cmd, "@CartDate", DbType.String, cart.CartDate);
                db.AddInParameter(cmd, "@ItemCount", DbType.String, cart.ItemCount);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Cart " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Cart SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Cookie], [CartDate], [ItemCount]" +
                "FROM dbo.Cart  " +
                "WHERE [Id]=@Id ";

            Cart cart = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        cart = LoadCart(dr);
                    }
                }
            }

            return cart;
        }


        public List<Cart> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Cookie], [CartDate], [ItemCount] " +
                "FROM dbo.Cart ";

            List<Cart> result = new List<Cart>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Cart cart = LoadCart(dr);
                        result.Add(cart);
                    }
                }
            }

            return result;
        }


        private Cart LoadCart(IDataReader dr)
        {
            Cart cart = new Cart();

            cart.Id = GetDataValue<int>(dr, "Id");
            cart.Cookie = GetDataValue<string>(dr, "Cookie");
            cart.CartDate = GetDataValue<DateTime>(dr, "CartDate");
            cart.ItemCount = GetDataValue<int>(dr, "ItemCount");

            return cart;
        }
    }
}

