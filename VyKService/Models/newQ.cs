using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VyKService.Models
{
    public class newQ
    {
        [Key]
        public int ID { get; set; }
        public string Question { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Time { get; set; }

    }
}
