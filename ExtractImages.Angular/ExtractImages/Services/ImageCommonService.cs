using ExtractImages.Constants;
using ExtractImages.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExtractImages.Services
{
    public class ImageCommonService
    {
        private readonly DatabaseServiceAccess _databaseService;
        public ImageCommonService(DatabaseServiceAccess databaseService)
        {
            _databaseService = databaseService;
        }

        public void ClearAllData()
        {
            _databaseService.ClearAllData();
        }

        public IEnumerable<ImagesDto> ExtractImages()
        {
            ClearAllData(); //Remove all the items before making another extraction
            return _databaseService.GetNewItemsFromDb();
        }
    }
}
