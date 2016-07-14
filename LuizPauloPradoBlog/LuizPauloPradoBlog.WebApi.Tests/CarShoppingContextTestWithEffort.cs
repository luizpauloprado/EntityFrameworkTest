using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuizPauloPradoBlog.Repository.Context;
using LuizPauloPradoBlog.Repository.Interface;
using Effort;
using LuizPauloPradoBlog.Repository;
using LuizPauloPradoBlog.Repository.Model;
using System.Linq;

namespace LuizPauloPradoBlog.Tests
{
    [TestClass]
    public class CarShoppingContextTestWithEffort
    {
        private CarShoppingContext _context;
        private ICarRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();

            _context = new CarShoppingContext(connection);
            _repository = new CarRepository(_context);
        }

        [TestMethod]
        public void ShoudCreateNewCar()
        {
            var car = new Car() { Name = "Fiesta", Model = "Fiesta SE", YearOfManufacture = 2015 };
            _repository.Add(car);

            Assert.IsTrue(car.Id != 0);
        }

        [TestMethod]
        public void ShoudGetCarById()
        {
            var sampleCar = new Car() { Name = "Fiesta", Model = "Fiesta SE", YearOfManufacture = 2015 };
            _repository.Add(sampleCar);

            var car = _repository.Get(sampleCar.Id);

            Assert.IsNotNull(car);
            Assert.IsTrue(car.Id != 0);
            Assert.IsTrue(car.Name == sampleCar.Name);
            Assert.IsTrue(car.Model == sampleCar.Model);
            Assert.IsTrue(car.YearOfManufacture == sampleCar.YearOfManufacture);
        }

        [TestMethod]
        public void ShoudGetAllCars()
        {
            var sampleCarFiesta = new Car() { Name = "Fiesta", Model = "Fiesta SE", YearOfManufacture = 2015 };
            var sampleCarGolf = new Car() { Name = "Golf", Model = "Golf Sport", YearOfManufacture = 2015 };
            _repository.Add(sampleCarFiesta);
            _repository.Add(sampleCarGolf);

            var cars = _repository.GetAll();

            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Any());
            Assert.IsTrue(cars[0].Id == sampleCarFiesta.Id);
            Assert.IsTrue(cars[1].Id == sampleCarGolf.Id);
        }
    }
}
