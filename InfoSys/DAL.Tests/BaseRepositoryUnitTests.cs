using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Moq;

namespace DAL.Tests
{
    class TestBuildingRepository
        : BaseRepository<Building>
    {
        public TestBuildingRepository(DbContext context) 
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputBuildingInstance_CalledAddMethodOfDBSetWithBuildingInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DistrictContext>()
                .Options;
            var mockContext = new Mock<DistrictContext>(opt);
            var mockDbSet = new Mock<DbSet<Building>>();
            mockContext
                .Setup(context => 
                    context.Set<Building>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestBuildingRepository(mockContext.Object);

            Building expectedBuilding = new Mock<Building>().Object;

            //Act
            repository.Create(expectedBuilding);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedBuilding
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DistrictContext>()
                .Options;
            var mockContext = new Mock<DistrictContext>(opt);
            var mockDbSet = new Mock<DbSet<Building>>();
            mockContext
                .Setup(context =>
                    context.Set<Building>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IItemRepository repository = uow.Items;
            var repository = new TestBuildingRepository(mockContext.Object);

            Building expectedBuilding = new Building() { building_id = 1};
            mockDbSet.Setup(mock => mock.Find(expectedBuilding.building_id)).Returns(expectedBuilding);

            //Act
            repository.Delete(expectedBuilding.building_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedBuilding.building_id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedBuilding
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<DistrictContext>()
                .Options;
            var mockContext = new Mock<DistrictContext>(opt);
            var mockDbSet = new Mock<DbSet<Building>>();
            mockContext
                .Setup(context =>
                    context.Set<Building>(
                        ))
                .Returns(mockDbSet.Object);

            Building expectedBuilding = new Building() { building_id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedBuilding.building_id))
                    .Returns(expectedBuilding);
            var repository = new TestBuildingRepository(mockContext.Object);

            //Act
            var actualBuilding = repository.Get(expectedBuilding.building_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedBuilding.building_id
                    ), Times.Once());
            Assert.Equal(expectedBuilding, actualBuilding);
        }

      
    }
}
