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
    public class BookCategoryEntity:BaseEntity
    {
        [Key]
        public Guid book_category_id { get; set; }

        [Description("รหัส")]
        [MaxLength(255)]
        public string code { get; set; }

        [Description("ชื่อหมวดหมู่")]
        [MaxLength(255)]
        public string name { get; set; }
    }
}
