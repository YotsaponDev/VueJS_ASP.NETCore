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
    public class BookEntity:BaseEntity
    {
        [Key]
        public Guid book_id { get; set; }

        [Description("ชื่อหนังสือ")]
        [MaxLength(255)]
        public string name { get; set; }

        [Description("รายละเอียด")]
        [MaxLength(5000)]
        public string detail { get; set; }

        [Description("ผู้แต่ง")]
        [MaxLength(255)]
        public string author { get; set; }

        [Description("สำนักพิมพ์")]
        [MaxLength(255)]
        public string publisher { get; set; }

        [Description("หมวดหมู่")]
        [ForeignKey("BookCategory")]
        public Guid book_category_id { get; set; }
        public BookCategoryEntity BookCategory { get; set; }

        [Description("จำนวนหน้า")]
        public int number_of_page { get; set; }

        [Description("รูปภาพ")]
        [MaxLength(1000)]
        public string image { get; set; }
    }
}
