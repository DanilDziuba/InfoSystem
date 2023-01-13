using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class BuildingDTO
    {
        public int building_id { get; set; }
        public int owner_id { get; set; }
        public int balance { get; set; }
        public String type { get; set; }
        public bool water_status { get; set; }
        public bool electricity_status { get; set; }
        public bool heating_status { get; set; }
    }
}
