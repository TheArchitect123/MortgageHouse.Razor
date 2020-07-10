using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace ExtractImages.SqlServer.Driver.Helpers
{
    public static class SqlHelper
    {
        public static List<T> RawSqlQuery<T>(this DbContext context, string query, Func<DbDataReader, T> map)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    var entities = new List<T>();
                    while (result.Read())
                        entities.Add(map(result));

                    return entities;
                }
            }
        }

        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(T);
            else
                return (T)obj;
        }
    }
}
