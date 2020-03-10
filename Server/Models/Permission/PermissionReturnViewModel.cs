using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class PermissionReturnViewModel
    {
        public Guid permission_id { get; set; }

        public Guid member_id { get; set; }

        public string permission_type { get; set; }
    }
}
