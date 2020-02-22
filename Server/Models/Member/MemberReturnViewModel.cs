using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class MemberReturnViewModel
    {
        public Guid member_id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public DateTime? birthday { get; set; }

        public string sex { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}
