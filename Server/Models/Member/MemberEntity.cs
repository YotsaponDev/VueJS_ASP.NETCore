using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class MemberEntity
    {
        [Key]
        public Guid member_id { get; set; }

        [Description("ชื่อ")]
        [MaxLength(255)]
        public string firstname { get; set; }

        [Description("นามสกุล")]
        [MaxLength(255)]
        public string lastname { get; set; }

        [Description("วันเกิด")]
        public DateTime? birthday { get; set; }

        [Description("เพศ")]
        [MaxLength(10)]
        public string sex { get; set; }

        [Description("อีเมล์")]
        [MaxLength(255)]
        public string email { get; set; }

        [Description("รหัสผ่าน")]
        [MaxLength(255)]
        public string password { get; set; }

        [Description("วันเวลาที่สร้าง")]
        public DateTime? created_at { get; set; }

        [Description("วันเวลาที่แก้ไข")]
        public DateTime? updated_at { get; set; }
    }
}
