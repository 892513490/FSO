using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FSO.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }

        [Column("creator_id")]
        public long? CreatorId { get; set; }

        public string Creator { get; set; }

        [Column("create_date")]
        public DateTime? CreateDate { get; set; }

        [Column("modify_date")]
        public DateTime? ModifyDate { get; set; }

        public int Status { get; set; }

        public BaseModel()
        {
            this.CreateDate = DateTime.Now;
            this.ModifyDate = DateTime.Now;
            this.Status = (int)EnumStatus.N;
        }
    }
}
