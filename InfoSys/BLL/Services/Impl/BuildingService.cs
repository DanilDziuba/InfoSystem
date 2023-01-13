using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using BLL.DTO;
using DAL.Repositories.Interfaces;
using AutoMapper;
using DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;
using System.Security.Cryptography;

namespace BLL.Services.Impl
{
    public class BuildingService
        : IBuildingService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public BuildingService( 
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<BuildingDTO> GetBuildings(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            var ownerID = user.UID;
            var itemsEntities = 
                _database
            .Buildings
                    .Find(z => z.owner_id == ownerID, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Building, BuildingDTO>()
                    ).CreateMapper();
            var buildingsDto = 
                mapper
                    .Map<IEnumerable<Building>, List<BuildingDTO>>(
                        itemsEntities);
            return buildingsDto;
        }

        public void AddBuilding(BuildingDTO building)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Manager)
                || userType != typeof(Director))
            {
                throw new MethodAccessException();
            }
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            validate(building);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BuildingDTO, Building>()).CreateMapper();
            var buildingEntity = mapper.Map<BuildingDTO, Building>(building);
            _database.Buildings.Create(buildingEntity);
        }

        private void validate(BuildingDTO building)
        {
            if (building.owner_id < 0)
            {
                throw new ArgumentException("Building must have a valid owner");
            }
        }
    }
}
