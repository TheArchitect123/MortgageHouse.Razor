using System;
using System.Collections.Generic;
using System.Text;

namespace ExtractImages.SqlServer.Driver.Constants
{
    public static class QueryConstants
    {
        public static string GetOldItemsQuery()
        {
            return "SELECT [image_id] ,[upload_obua_id] ,[document_type_id] ,[upload_date], [Record_Create_Date], " +
                "[application_id], [last_download_timestamp], [last_download_obua_id], [description]," +
                " [filename], [image] FROM[MortgageHouse.Import].[dbo].[old]";
        }
    }
}
