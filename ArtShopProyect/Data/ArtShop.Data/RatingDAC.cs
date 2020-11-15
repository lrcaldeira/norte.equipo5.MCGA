using ArtShop.Entities.Model;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ArtShop.Data
{
    public partial class RatingDAC : DataAccessComponent
    {
        public Rating Create(Rating rating)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Rating ([Stars], [UserName]) " +
                "VALUES(@Stars, @UserName); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Stars", DbType.Int32, rating.Stars);
                db.AddInParameter(cmd, "@UserName", DbType.String, rating.UserName);
                
                rating.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return rating;
        }

        public void UpdateById(Rating rating)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Rating " +
                "SET " +
                    "[Stars]=@Stars, " +
                    "[UserName]=@UserName " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Stars", DbType.Int32, rating.Stars);
                db.AddInParameter(cmd, "@UserName", DbType.String, rating.UserName); 
                db.AddInParameter(cmd, "@Id", DbType.Int32, rating.Id);

                db.ExecuteNonQuery(cmd);
            }
        }


        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.Rating " +
                                         "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public Rating SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Stars], [UserName] " +
                "FROM dbo.Rating  " +
                "WHERE [Id]=@Id ";

            Rating rating = null;

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        rating = LoadRating(dr);
                    }
                }
            }

            return rating;
        }


        public List<Rating> Select()
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [Stars], [UserName] " +
                "FROM dbo.Rating";

            List<Rating> result = new List<Rating>();

            var db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        Rating rating = LoadRating(dr);
                        result.Add(rating);
                    }
                }
            }

            return result;
        }


        private Rating LoadRating(IDataReader dr)
        {
            Rating rating = new Rating();

            rating.Id = GetDataValue<int>(dr, "Id");
            rating.Stars = GetDataValue<int>(dr, "Stars");
            rating.UserName = GetDataValue<string>(dr, "UserName");

            return rating;
        }
    }
}
