using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Application
    {
        [Key]
        public int app_id { get; set; }
        public String status { get; set; }
    }
}
