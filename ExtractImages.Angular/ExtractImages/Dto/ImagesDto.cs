using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtractImages.Dto
{
    public class ImagesDto
    {
        public long ImageID { get; set; }
        public long UploadOBUAID { get; set; }
        public long DocumentTypeID { get; set; }

        public DateTime UploadDate { get; set; }
        public DateTime RecordCreateDate { get; set; }
        public long ApplicationID { get; set; }

        public string FileName { get; set; }
        public string ImageDescription { get; set; }
        public string ImageFilePath { get; set; }
    }
}
