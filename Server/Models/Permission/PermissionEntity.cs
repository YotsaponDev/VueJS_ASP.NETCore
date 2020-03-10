using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class PermissionEntity
    {
        [Key]
        public Guid permission_id { get; set; }

        [Description("รหัสสมาชิก")]
        public Guid member_id { get; set; }
        public MemberEntity Member { get; set; }

        [Description("ประเภทสิทธิ")]
        [MaxLength(100)]
        public string permission_type { get; set; }

        [Description("วันเวลาที่สร้าง")]
        public DateTime? created_at { get; set; }

        [Description("วันเวลาที่แก้ไข")]
        public DateTime? updated_at { get; set; }
    }
}
