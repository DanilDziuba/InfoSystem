using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Land
    {
        [Key]
        public int land_id { get; set; }
        public float area { get; set; }
        Building building { get; set; }
        LandLeaseCost llc { get; set; }

    }
}
