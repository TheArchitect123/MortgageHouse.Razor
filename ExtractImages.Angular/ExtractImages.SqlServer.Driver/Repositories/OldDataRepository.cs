using ExtractImages.SqlServer.Driver.Constants;
using ExtractImages.SqlServer.Driver.Entities;
using ExtractImages.SqlServer.Driver.Helpers;
using Microsoft.EntityFrameworkCore;
using MortgageHouse.Backend.SqlServerDriver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ExtractImages.SqlServer.Driver.Repositories
{
    public class OldDataRepository
    {
        public OldDataRepository(ContentDb contentMngr)
        {
            _contentMngr = contentMngr;
        }

        public ContentDb _contentMngr;

        private Old MapOldItemFromSql(DbDataReader item)
        {
            return new Old()
            {
                image_id = SqlHelper.ConvertFromDBVal<int>(item[0]),
                upload_obua_id = SqlHelper.ConvertFromDBVal<int>(item[1]),
                document_type_id = SqlHelper.ConvertFromDBVal<int>(item[2]),
                upload_date = SqlHelper.ConvertFromDBVal<DateTime>(item[3]),
                Record_Create_Date = SqlHelper.ConvertFromDBVal<DateTime>(item[4]),
                application_id = SqlHelper.ConvertFromDBVal<int>(item[5]),
                last_download_timestamp = SqlHelper.ConvertFromDBVal<DateTime>(item[6]),
                last_download_obua_id = SqlHelper.ConvertFromDBVal<int>(item[7]),
                description = SqlHelper.ConvertFromDBVal<string>(item[8]),
                filename = SqlHelper.ConvertFromDBVal<string>(item[9]),
                image = SqlHelper.ConvertFromDBVal<byte[]>(item[10])
            };
        }
        public IEnumerable<Old> GetOldItems()
        {
            try
            {
                //Run a raw sql query, considering that the entity already exists. This saves me from having to migrate data and export another bacpac file
                return this._contentMngr.RawSqlQuery<Old>(QueryConstants.GetOldItemsQuery(), (oldItem) => MapOldItemFromSql(oldItem));
            }
            catch (Exception ex)
            {
                //Add some logging here...
                throw ex;
            }
        }
    }
}
