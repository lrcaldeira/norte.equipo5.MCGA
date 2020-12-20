using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
    public partial class OrderDAC : DataAccessComponent
    {
        public Order Create(Order order)

        {
            const string SQL_STATEMENT = "insert into [dbo].[Order] (UserId,OrderDate,TotalPrice,OrderNumber,ItemCount) values (@UserId,@OrderDate,@TotalPrice,@OrderNumber,@ItemCount) SELECT SCOPE_IDENTITY()";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, order.UserId);
                db.AddInParameter(cmd, "@OrderDate", DbType.DateTime, order.OrderDate);
                db.AddInParameter(cmd, "@TotalPrice", DbType.Double, order.TotalPrice);
                db.AddInParameter(cmd, "@OrderNumber", DbType.Int32, order.OrderNumber);
                db.AddInParameter(cmd, "@ItemCount", DbType.Int32, order.ItemCount);

                order.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return order;

        }

        public Order UpdateById(Order order)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Order " +
                "SET " +
                    "[OrderDate]=@OrderDate, " +
                    "[TotalPrice]=@TotalPrice, " +
                    "[OrderNumber]=@OrderNumber, " +
                    "[ItemCount]=@ItemCount, " +
                    "[UserName]=@UserName " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@OrderDate", DbType.String, order.OrderDate);
                db.AddInParameter(cmd, "@TotalPrice", DbType.String, order.TotalPrice);
                db.AddInParameter(cmd, "@OrderNumber", DbType.String, order.OrderNumber);
                db.AddInParameter(cmd, "@ItemCount", DbType.String, order.ItemCount);
                db.AddInParameter(cmd, "@UserName", DbType.String, order.UserId);


                db.ExecuteNonQuery(cmd);
            }

            return order;
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.order " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Order SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [OrderDate], [TotalPrice], [OrderNumber], [ItemCount], [UserName]" +
                "FROM dbo.Order  " +
                "WHERE [Id]=@Id ";

            Order order = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        order = LoadOrder(dr);
                    }
                }
            }

            return order;
        }


        public List<Order> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [OrderDate], [TotalPrice], [OrderNumber], [ItemCount], [UserName] " +
                "FROM dbo.Order ";

            List<Order> result = new List<Order>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Order order = LoadOrder(dr);
                        result.Add(order);
                    }
                }
            }

            return result;
        }


        private Order LoadOrder(IDataReader dr)
        {
            Order order = new Order();

            order.Id = GetDataValue<int>(dr, "Id");
            order.TotalPrice = GetDataValue<double>(dr, "TotalPrice");
            order.OrderDate = GetDataValue<DateTime>(dr, "OrderDate");
            order.OrderNumber = GetDataValue<int>(dr, "OrderNumber");
            order.ItemCount = GetDataValue<int>(dr, "ItemCount");
            order.UserId = GetDataValue<string>(dr, "UserId");

            return order;
        }
    }
}
