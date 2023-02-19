using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services;
using TechStorage.Controllers;

namespace Tests
{
    [TestFixture]
    public class TechStorageControllerTests
    {
        private Mock<IRepositoryWrapper> _repositoryWrapper;
        [SetUp] 
        public void SetUp() 
        {
            _repositoryWrapper = new Mock<IRepositoryWrapper>();
            _repositoryWrapper.Setup(x => x.Contract.FindAll()).Returns(
                new List<Contract>()
                {
                    new Contract()
                    {
                        Id =1,
                        FacilityId= 1,
                        EquipmentId = 1,
                        Quantity = 2
                    },
                    new Contract()
                    {
                        Id =2,
                        FacilityId= 1,
                        EquipmentId = 2,
                        Quantity = 1
                    }
                });

            _repositoryWrapper.Setup(x => x.Facility.FindAll()).Returns(
                new List<Facility>()
                {
                    new Facility()
                    {
                        Id = 1,
                        Name = "TestFacility",
                        Capacity = 100

                    }
                });

            _repositoryWrapper.Setup(x => x.Equipment.FindAll()).Returns(
                new List<Equipment>()
                {
                    new Equipment()
                    {
                        Id = 1,
                        Name = "TestEquipment1",
                        Area = 20
                    },
                    new Equipment()
                    {
                        Id = 2,
                        Name = "TestEquipment2",
                        Area = 30
                    }
                });

        }


        [Test, Order(1)]
        public void Get_Contracts()
        {
            var controller = new TechStorageController(null, new StorageService(_repositoryWrapper.Object));

            var result = controller.Get();

            //Assert

            Assert.That(result, Is.Not.Null);
            Assert.AreEqual(result.Count(), 2);

        }

        [Test, Order(2)]
        public void Create_Contract_Have_Space()
        {
            var controller = new TechStorageController(null, new StorageService(_repositoryWrapper.Object));

            var actionResult = controller.Post(1, 2, 1);

            var result = actionResult as OkResult;

            //Assert
            Assert.AreEqual(result.StatusCode, 200);

            _repositoryWrapper.Verify(x => x.Contract.Create(It.IsAny<Contract>()), Times.Once);

        }

        [Test, Order(3)]
        public void Create_Contract_Not_Have_Space()
        {
            var controller = new TechStorageController(null, new StorageService(_repositoryWrapper.Object));

            var actionResult = controller.Post(1, 2, 3);

            var result = actionResult as ObjectResult;

            //Assert
            Assert.AreEqual(result.StatusCode, 500);
            Assert.AreEqual(result.Value, "There is no place in this facility");

            _repositoryWrapper.Verify(x => x.Contract.Create(It.IsAny<Contract>()), Times.Never);

        }

        [Test, Order(4)]
        public void Delete_Contract_Wrong_Id()
        {
            var controller = new TechStorageController(null, new StorageService(_repositoryWrapper.Object));

            var actionResult = controller.Delete(4);

            var result = actionResult as ObjectResult;

            //Assert
            Assert.AreEqual(result.StatusCode, 500);
            Assert.AreEqual(result.Value, "There is no contract with this id!");
            _repositoryWrapper.Verify(x => x.Contract.Delete(It.IsAny<Contract>()), Times.Never);
        }

        [Test, Order(5)]
        public void Delete_Contract_Correct_Id()
        {
            var controller = new TechStorageController(null, new StorageService(_repositoryWrapper.Object));

            var actionResult = controller.Delete(1);

            var result = actionResult as OkResult;

            //Assert
            Assert.AreEqual(result.StatusCode, 200);
            _repositoryWrapper.Verify(x => x.Contract.Delete(It.IsAny<Contract>()), Times.Once);
        }

        [Test, Order(6)]
        public void Update_Contract_Wrong_Facility_Id()
        {
            var controller = new TechStorageController(null, new StorageService(_repositoryWrapper.Object));

            var contract = new Contract()
            {
                Id = 1,
                FacilityId = 2,
                EquipmentId = 1,
                Quantity= 1
            };

            var actionResult = controller.Update(contract);

            var result = actionResult as ObjectResult;

            //Assert
            Assert.AreEqual(result.StatusCode, 500);
            Assert.AreEqual(result.Value, "There is no such facility!");

            _repositoryWrapper.Verify(x => x.Contract.Update(It.IsAny<Contract>()), Times.Never);

        }

        [Test, Order(7)]
        public void Update_Contract()
        {
            var controller = new TechStorageController(null, new StorageService(_repositoryWrapper.Object));

            var contract = new Contract()
            {
                Id = 1,
                FacilityId = 1,
                EquipmentId = 1,
                Quantity = 1
            };

            var actionResult = controller.Update(contract);

            var result = actionResult as OkResult;

            //Assert
            Assert.AreEqual(result.StatusCode, 200);

            _repositoryWrapper.Verify(x => x.Contract.Update(It.IsAny<Contract>()), Times.Once);

        }


    }
}