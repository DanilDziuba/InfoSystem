using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Remotion.Linq;

namespace DAL.Tests
{
    public class BuildingRepositoryInMemoryDBTests
    {
        public DistrictContext Context => SqlLiteInMemoryContext();

        private DistrictContext SqlLiteInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<DistrictContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new DistrictContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void Create_InputBuildingWithId0_SetItemId1()
        {
            // Arrange
            int expectedListCount = 1;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IBuildingRepository repository = uow.Buildings;

            Building building = new Building()
            {
                building_id = 1,
                owner_id = 1,
                balance = 1000,
                type = "Shop",
                water_status = false,
                electricity_status = true,
                heating_status = true
    };

            //Act
            repository.Create(building);
            uow.Save();
            var factListCount = context.buildings.Count();

            // Assert
            Assert.Equal(expectedListCount, factListCount);
        }

        [Fact]
        public void Delete_InputExistBuildingId_Removed()
        {
            // Arrange
            int expectedListCount = 0;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IBuildingRepository repository = uow.Buildings;
            Building building = new Building()
            {
                //building_id = 1,
                owner_id = 1,
                balance = 1000,
                type = "Shop",
                water_status = false,
                electricity_status = true,
                heating_status = true
            };
            context.buildings.Add(building);
            context.SaveChanges();

            //Act
            repository.Delete(building.building_id);
            uow.Save();
            var factBuildingCount = context.buildings.Count();

            // Assert
            Assert.Equal(expectedListCount, factBuildingCount);
        }

        [Fact]
        public void Get_InputExistBuildingId_ReturnBuilding()
        {
            // Arrange
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IBuildingRepository repository = uow.Buildings;
            Building expectedBuilding = new Building()
            {
                //building_id = 1,
                owner_id = 1,
                balance = 1000,
                type = "Shop",
                water_status = false,
                electricity_status = true,
                heating_status = true
            };
            context.buildings.Add(expectedBuilding);
            context.SaveChanges();

            //Act
            var factBuilding = repository.Get(expectedBuilding.building_id);

            // Assert
            Assert.Equal(expectedBuilding, factBuilding);
        }
    }
}
