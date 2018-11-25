using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FSO.Models
{
    [Table("T_VideoInfo")]
    public class VideoInfo:BaseModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Remark { get; set; }

        public string ImgUrl { get; set; }

        public string Url { get; set; }
    }
}
