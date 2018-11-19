using System;
using System.ComponentModel.DataAnnotations;

namespace FSO.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
    }
}
