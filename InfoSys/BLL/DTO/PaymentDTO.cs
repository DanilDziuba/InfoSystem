using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PaymentDTO
    {
        public int payment_id { get; set; }
        public DateTime date { get; set; }
        public float value { get; set; }
    }
}
