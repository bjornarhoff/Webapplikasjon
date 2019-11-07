using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VyKService.Models
{
    public class QA
    {
        [Key]
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

    }
}
