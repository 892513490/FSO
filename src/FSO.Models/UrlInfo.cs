using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSO.Models
{
    [Table("T_UrlInfo")]
    public class UrlInfo: BaseModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Remark { get; set; }
    }
}
