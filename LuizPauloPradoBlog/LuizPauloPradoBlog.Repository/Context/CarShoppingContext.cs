using LuizPauloPradoBlog.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizPauloPradoBlog.Repository.Context
{
    public class CarShoppingContext : DbContext
    {
        public CarShoppingContext() { }
        public CarShoppingContext(DbConnection connection) : base(connection, true) { }

        public virtual DbSet<Car> Cars { get; set; }
    }
}
