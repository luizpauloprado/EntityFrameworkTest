using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LuizPauloPradoBlog.Repository.Model;
using System.Linq;
using Moq;
using System.Data.Entity;
using LuizPauloPradoBlog.Repository.Context;
using LuizPauloPradoBlog.Repository;
using LuizPauloPradoBlog.Repository.Interface;

namespace LuizPauloPradoBlog.Tests
{
    [TestClass]
    public class CarShoppingContextTestWithMock
    {
        private Mock<DbSet<Car>> _dbSet;
        private Mock<CarShoppingContext> _context;
        private ICarRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            var sampleData = new List<Car>()
            {
                new Car() { Id = 1, Name = "Fiesta", Model = "Fiesta SE", YearOfManufacture = 2015 },
                new Car() { Id = 2, Name = "Golf", Model = "Golf Sport", YearOfManufacture = 2015 }
            }.AsQueryable();

            _dbSet = new Mock<DbSet<Car>>();
            _dbSet.As<IQueryable<Car>>().Setup(x => x.Provider).Returns(sampleData.Provider);
            _dbSet.As<IQueryable<Car>>().Setup(x => x.Expression).Returns(sampleData.Expression);
            _dbSet.As<IQueryable<Car>>().Setup(x => x.ElementType).Returns(sampleData.ElementType);
            _dbSet.As<IQueryable<Car>>().Setup(x => x.GetEnumerator()).Returns(sampleData.GetEnumerator());

            _context = new Mock<CarShoppingContext>();
            _context.Setup(x => x.Cars).Returns(_dbSet.Object);

            _repository = new CarRepository(_context.Object);
        }

        [TestMethod]
        public void ShoudCreateNewCar()
        {
            var sampleCar = new Car() { Id = 3, Name = "Civic", Model = "Honda Civic SE", YearOfManufacture = 2016 };
            _repository.Add(sampleCar);

            _dbSet.Verify(m => m.Add(It.IsAny<Car>()), Times.Once());
            _context.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void ShoudGetAllCars()
        {
            var cars = _repository.GetAll();

            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Any());
        }
    }
}
