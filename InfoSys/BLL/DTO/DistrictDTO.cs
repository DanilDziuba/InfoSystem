using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class DistrictDTO
    {
        public int district_id { get; set; }
        public List<Application> applications { get; set; }
        public List<Building> buildings { get; set; }
        public List<Land> lands { get; set; }
        public List<Payment> payments { get; set; }
        public List<LandLeaseCost> land_Lease_Costs { get; set; }
    }
}


