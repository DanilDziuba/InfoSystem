using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }
        public DateTime date { get; set; }
        public float value { get; set; }

    }
}
