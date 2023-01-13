using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Resident = CCL.Security.Identity.Resident;

namespace BLL.Tests
{
    public class BuildingServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new BuildingService(nullUnitOfWork));
        }

        [Fact]
        public void AddBuilding_UserIsResident_ThrowMethodAccessException()
        {
            // Arrange
            Resident user = new Resident(1, "test", "Resident");
            SecurityContext.SetUser(user, true);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IBuildingService buildingService = new BuildingService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => buildingService.AddBuilding(null));
        }

        [Fact]
        public void GetBuilding_BuildingFromDAL_CorrectMappingToBuildingDTO()
        {
            // Arrange
            Resident user = new Director(1, "test", 1);
            SecurityContext.SetUser(user, true);
            var buildingService = GetBuildingService();

            // Act
            var actualBuildingDTO = buildingService.GetBuildings(0).First();

            // Assert
            Assert.True(
                actualBuildingDTO.building_id == 1
                && actualBuildingDTO.owner_id == 1
                && actualBuildingDTO.balance == 1000
                );
        }

        IBuildingService GetBuildingService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedBuilding = new Building() { building_id = 1, balance = 1000, water_status = false, type = "House",
                electricity_status = false, heating_status = true, owner_id = 1};
            var mockDbSet = new Mock<IBuildingRepository>();
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<Building,bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<Building>() { expectedBuilding }
                    );
            mockContext
                .Setup(context =>
                    context.Buildings)
                .Returns(mockDbSet.Object);

            IBuildingService buildingService = new BuildingService(mockContext.Object);

            return buildingService;
        }
    }
}
