using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
    public partial class ErrorDAC : DataAccessComponent
    {
        public Error Create(Error error)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Error ([UserName], [ErrorDate], [Ip Adress], [User Agent], [Exception], [Message], " +
                "[Everything], [Http Referer], [Path And Query])" +
                "VALUES(@UserName, @ErrorDate, @IpAdress, @UserAgent, @Exception, @Message, " +
                "@Everything, @HttpReferer, @PathAndQuery); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserName", DbType.String, error.UserName);
                db.AddInParameter(cmd, "@ErrorDate", DbType.DateTime, error.ErrorDate);
                db.AddInParameter(cmd, "@IpAdress", DbType.String, error.IpAddress);
                db.AddInParameter(cmd, "@UserAgent", DbType.String, error.UserAgent);
                db.AddInParameter(cmd, "@Exception", DbType.String, error.Exception);
                db.AddInParameter(cmd, "@Message", DbType.String, error. Message);
                db.AddInParameter(cmd, "@Everything", DbType.String, error.Everything);
                db.AddInParameter(cmd, "@HttpReferer", DbType.String, error.HttpReferer);
                db.AddInParameter(cmd, "@PathAndQuery", DbType.String, error.PathAndQuery);

                error.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return error;
        }

        public void UpdateById(Error error)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Error " +
                "SET " +
                    "[UserName]=@UserName, " +
                    "[ErrorDate]=@ErrorDate, " +
                    "[IpAdress]=@IpAdress, " +
                    "[UserAgent]=@UserAgent, " +
                    "[Exception]=@Exception, " +
                    "[Message]=@Message, " +
                    "[Everything]=@Everything, " +
                    "[HttpReferer]=@HttpReferer, " +
                    "[PathAndQuery]=@PathAndQuery " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@UserName", DbType.String, error.UserName);
                db.AddInParameter(cmd, "@ErrorDate", DbType.DateTime, error.ErrorDate);
                db.AddInParameter(cmd, "@IpAdress", DbType.String, error.IpAddress);
                db.AddInParameter(cmd, "@UserAgent", DbType.String, error.UserAgent);
                db.AddInParameter(cmd, "@Exception", DbType.String, error.Exception);
                db.AddInParameter(cmd, "@Message", DbType.String, error.Message);
                db.AddInParameter(cmd, "@Everything", DbType.String, error.Everything);
                db.AddInParameter(cmd, "@HttpReferer", DbType.String, error.HttpReferer);
                db.AddInParameter(cmd, "@PathAndQuery", DbType.String, error.PathAndQuery);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Error " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Error SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [UserName], [ErrorDate], [Ip Adress], [User Agent], [Exception], [Message], " +
                "[Everything], [Http Referer], [Path And Query]" +
                "FROM dbo.Error  " +
                "WHERE [Id]=@Id ";

            Error error = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        error = LoadError(dr);
                    }
                }
            }

            return error;
        }


        public List<Error> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [UserName], [ErrorDate], [Ip Adress], [User Agent], [Exception], [Message], " +
                "[Everything], [Http Referer], [Path And Query]" +
                "FROM dbo.Error ";

            List<Error> result = new List<Error>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Error error = LoadError(dr);
                        result.Add(error);
                    }
                }
            }

            return result;
        }


        private Error LoadError(IDataReader dr)
        {
            Error error = new Error();

            error.Id = GetDataValue<int>(dr, "Id");
            error.UserName = GetDataValue<string>(dr, "UserName");
            error.ErrorDate = GetDataValue<DateTime>(dr, "ErrorDate");
            error.UserAgent = GetDataValue<string>(dr, "UserAgent");
            error.Exception = GetDataValue<string>(dr, "Exception");
            error.Message = GetDataValue<string>(dr, "Message");
            error.Everything = GetDataValue<string>(dr, "Everything");
            error.HttpReferer = GetDataValue<string>(dr, "HttpReferer");
            error.PathAndQuery = GetDataValue<string>(dr, "PathAndQuery");

            return error;
        }
    }
}
