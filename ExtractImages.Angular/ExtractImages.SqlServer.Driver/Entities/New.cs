using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtractImages.SqlServer.Driver.Entities
{
    public class New
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
