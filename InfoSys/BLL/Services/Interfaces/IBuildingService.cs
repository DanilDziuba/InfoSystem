using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Interfaces
{
    public interface IBuildingService
    {
        IEnumerable<BuildingDTO> GetBuildings(int page);
        void AddBuilding(BuildingDTO building);
    }
}
