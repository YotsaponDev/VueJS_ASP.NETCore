using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Server.Models
{
    public class BaseEntity
    {
        [Description("วันเวลาที่สร้าง")]
        public DateTime? created_at { get; set; }

        [Description("วันเวลาที่แก้ไข")]
        public DateTime? updated_at { get; set; }
    }
}
