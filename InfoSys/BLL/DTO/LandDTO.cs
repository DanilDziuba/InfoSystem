using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class LandDTO
    {
        public int land_id { get; set; }
        public float area { get; set; }
        Building building { get; set; }
        LandLeaseCost llc { get; set; }
    }
}
