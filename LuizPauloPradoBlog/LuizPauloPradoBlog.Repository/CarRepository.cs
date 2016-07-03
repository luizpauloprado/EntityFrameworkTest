using LuizPauloPradoBlog.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuizPauloPradoBlog.Repository.Model;
using LuizPauloPradoBlog.Repository.Context;

namespace LuizPauloPradoBlog.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarShoppingContext _context;

        public CarRepository(CarShoppingContext context)
        {
            _context = context;
        }

        public IList<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public Car Get(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }
    }
}
