using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Models
{
    public class student_record : Entity
    {
        public string name { get; set; }
        public DateTime? date_of_birth { get; set; }
        
        public class_record class_record { get; set; }
        [ForeignKey("class_record")]
        public int class_id { get; set; }

        public country_record country_record { get; set; } 
        [ForeignKey("country_record")]
        public int country_id { get; set; }
    }
}
