using System;

namespace FSO.Models
{
    public class UserInfo
    {
        public long Id { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int? Sex { get; set; }

        public int? Age { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
