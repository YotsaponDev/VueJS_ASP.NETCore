using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class BookCategoryViewModel
    {
        public Guid book_category_id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

    }
}
