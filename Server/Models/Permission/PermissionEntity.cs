using Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class PermissionEntity:BaseEntity
    {
        [Key]
        public Guid permission_id { get; set; }

        [Description("รหัสสมาชิก")]
        public Guid member_id { get; set; }
        public MemberEntity Member { get; set; }

        [Description("ประเภทสิทธิ")]
        [MaxLength(100)]
        public string permission_type { get; set; }
    }
}
