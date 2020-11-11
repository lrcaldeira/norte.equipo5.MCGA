using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
    public partial class OrderDetailDAC: DataAccessComponent
    {
        public OrderDetail Create(OrderDetail orderdetail)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.OrderDetail ([Price], [Quantity], [OrderId], [ProductId]) " +
                "VALUES(@Price, @Quantity, @OrderId, @ProductId); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Price", DbType.String, orderdetail.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.String, orderdetail.Quantity);
                db.AddInParameter(cmd, "@OrderId", DbType.String, orderdetail.OrderId);
                db.AddInParameter(cmd, "@ProductId", DbType.String, orderdetail.ProductId);

                orderdetail.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return orderdetail;
        }

        public void UpdateById(OrderDetail orderdetail)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.OrderDetail " +
                "SET " +
                    "[Price]=@Price, " +
                    "[Quantity]=@Quantity, " +
                    "[OrderId]=@OrderId, " +
                    "[ProductId]=@ProductId, " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Price", DbType.String, orderdetail.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.String, orderdetail.Quantity);
                db.AddInParameter(cmd, "@OrderId", DbType.String, orderdetail.OrderId);
                db.AddInParameter(cmd, "@ProductId", DbType.String, orderdetail.ProductId);
                db.AddInParameter(cmd, "@Id", DbType.Int32, orderdetail.Id);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.OrderDetail " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public OrderDetail SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Price], [Quantity], [OrderId], [ProductId] " +
                "FROM dbo.OrderDetail  " +
                "WHERE [Id]=@Id ";

            OrderDetail orderdetail = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        orderdetail = LoadOrderDetail(dr);
                    }
                }
            }

            return orderdetail;
        }


        public List<OrderDetail> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Price], [Quantity], [OrderId], [ProductId] " +
                "FROM dbo.OrderDetail";

            List<OrderDetail> result = new List<OrderDetail>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        OrderDetail orderdetail = LoadOrderDetail(dr);
                        result.Add(orderdetail);
                    }
                }
            }

            return result;
        }


        private OrderDetail LoadOrderDetail(IDataReader dr)
        {
            OrderDetail orderdetail = new OrderDetail();

            orderdetail.Id = GetDataValue<int>(dr, "Id");
            orderdetail.Price = GetDataValue<double>(dr, "Price");
            orderdetail.Quantity = GetDataValue<int>(dr, "Quantity");
            orderdetail.OrderId = GetDataValue<int>(dr, "OrderId");
            orderdetail.ProductId = GetDataValue<int>(dr, "ProductId");

            return orderdetail;
        }
    }
}
