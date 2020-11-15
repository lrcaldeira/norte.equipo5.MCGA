using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
    public partial class OrderNumberDAC : DataAccessComponent
    {
        public OrderNumber Create(OrderNumber ordernumber)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.OrderNumber ([Number]) " +
                "VALUES(@Number); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Number", DbType.Int32, ordernumber.Number);

                ordernumber.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return ordernumber;
        }

        public void UpdateById(OrderNumber ordernumber)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.OrderNumber " +
                "SET "+
                    "[Number]=@Number " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Number", DbType.String, ordernumber.Number);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.OrderNumber " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public OrderNumber SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Number]" +
                "FROM dbo.OrderNumber  " +
                "WHERE [Id]=@Id ";

            OrderNumber ordernumber = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        ordernumber = LoadOrderNumber(dr);
                    }
                }
            }

            return ordernumber;
        }


        public List<OrderNumber> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Number] " +
                "FROM dbo.OrderNumber ";

            List<OrderNumber> result = new List<OrderNumber>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        OrderNumber ordernumber = LoadOrderNumber(dr);
                        result.Add(ordernumber);
                    }
                }
            }

            return result;
        }


        private OrderNumber LoadOrderNumber(IDataReader dr)
        {
            OrderNumber ordernumber = new OrderNumber();

            ordernumber.Id = GetDataValue<int>(dr, "Id");
            ordernumber.Number = GetDataValue<int>(dr, "Number");
            return ordernumber;
        }
    }
}
