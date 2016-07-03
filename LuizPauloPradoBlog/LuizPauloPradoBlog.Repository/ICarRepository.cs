using LuizPauloPradoBlog.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizPauloPradoBlog.Repository.Interface
{
    public interface ICarRepository
    {
        IList<Car> GetAll();
        Car Get(int id);
        void Add(Car car);
    }
}
