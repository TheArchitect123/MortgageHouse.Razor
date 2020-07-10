using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtractImages.Dto
{
    public class ImagesDto
    {
        public int image_id { get; set; }
        public int upload_obua_id { get; set; }
        public int document_type_id { get; set; }

        public DateTime upload_date { get; set; }
        public DateTime Record_Create_Date { get; set; }
        public DateTime last_download_timestamp { get; set; }

        public int last_download_obua_id { get; set; }

        public string description { get; set; }
        public string filename { get; set; }
        public string imagePath { get; set; }
    }
}
