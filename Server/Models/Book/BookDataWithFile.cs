using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class BookDataWithFile
    {
        public Guid book_id { get; set; }

        public string name { get; set; }

        public string detail { get; set; }

        public string author { get; set; }

        public string publisher { get; set; }

        public Guid book_category_id { get; set; }

        public int number_of_page { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        public IEnumerable<IFormFile> image { get; set; }
    }
}
