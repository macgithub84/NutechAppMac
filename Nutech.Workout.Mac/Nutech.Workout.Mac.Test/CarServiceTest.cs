using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.RegistrationByConvention;
using Nutech.Workout.Mac.Service.Services;
using Nutech.Workout.Mac.Data.Repositories;
using Unity.Injection;
using Moq;
using System.Collections.Generic;
using Nutech.Workout.Mac.Domain.Entities;

namespace Nutech.Workout.Mac.Test
{
    [TestClass]
    public class CarServiceTest
    {
        /// <summary> 
        /// Internal chip service locator. 
        /// </summary> 
        //private IServiceLocator serviceLocator;
        /// <summary> 
        /// Unity container. 
        /// </summary> 
        private IUnityContainer container;
        /// Initialize tests. 
        /// </summary> 
        private ICarService oCarService;
        [TestInitialize]
        public void InitializeTests()
        {
            container = new UnityContainer();
            container.RegisterTypes(
                       AllClasses.FromLoadedAssemblies(),
                       WithMappings.FromMatchingInterface,
                       WithName.Default);
            // container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType(
                    typeof(IRepository<>),
                    typeof(Repository<>),
                    new InjectionConstructor());
            oCarService = container.Resolve<ICarService>();
        }

        [TestMethod]
        public void Createk_Car()
        {

            var c = new Car { CarMake = "Ford", CarModel = "F1", Manufacturer = "Ford", YearOfManufacture = 2014 };
            var r = oCarService.CreateEntity(c);

            var mockService = new Mock<ICarService>();

            var res = mockService.Setup(x => x.CreateEntity(c)).Returns(r);
            res.Verifiable();
        }
        [TestMethod]
        public void Get_Cars_List()
        {
         
            var mockService = new Mock<ICarService>();
            var actual = oCarService.GetEntities();
            var res = mockService.Setup(x => x.GetEntities()).Returns(actual);
            res.Verifiable();
        }
    }
}
