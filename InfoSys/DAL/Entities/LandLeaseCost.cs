using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class LandLeaseCost
    {
        [Key]
        public int llc_id { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
