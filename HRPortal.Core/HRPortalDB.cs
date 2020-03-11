using PetaPoco;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HRPortal.Core
{
    public static class HRPortalDB
    {
        static Database db = new Database();

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }

        public static string ConnectionStringName
        {
            get
            {
                return AppSettings.HRPortalDBConnectionName ;
            }
        }

        public static object Insert(object entity)
        {
            using (var db = new Database(ConnectionStringName))
            {
                return db.Insert(entity);
            }
        }

        public static IEnumerable<object> Insert(IEnumerable<object> entities, bool UseTransaction)
        {
            List<object> ids = new List<object>();
            using (var db = new Database(ConnectionStringName))
            {
                try
                {
                    if (UseTransaction)
                        db.BeginTransaction();
                    foreach (var entity in entities)
                    {
                        var id = db.Insert(entity);
                        ids.Add(id);
                    }
                    if (UseTransaction)
                        db.CompleteTransaction();
                }
                catch (Exception e)
                {
                    if (UseTransaction)
                        db.AbortTransaction();
                    throw e;
                }
            }

            return ids;
        }

        public static int Update(object entity)
        {
            using (var db = new Database(ConnectionStringName))
            {
                return db.Update(entity);
            }
        }

        public static T ExecuteScalar<T>(string sql, params object[] args)
        {
            using (var db = new Database(ConnectionStringName))
            {
                return db.ExecuteScalar<T>(sql, args);
            }
        }

        public static T SingleOrDefault<T>(string sql, params object[] args)
        {
            using (var db = new Database(ConnectionStringName))
            {
                return db.SingleOrDefault<T>(sql,args);
            }
        }

        public static T FirstOrDefault<T>(string sql, params object[] args)
        {
            using (var db = new Database(ConnectionStringName))
            {
                return db.FirstOrDefault<T>(sql, args);
            }
        }

        public static List<T> Fetch<T>()
        {
            using (var db = new Database(ConnectionStringName))
            {
                return db.Fetch<T>("");
            }
        }

        public static List<T> Fetch<T>(string sql, params object[] args)
        {
            using (var db = new Database(ConnectionStringName))
            {
                return db.Fetch<T>(sql,args);
            }
        }
      
    }
}
