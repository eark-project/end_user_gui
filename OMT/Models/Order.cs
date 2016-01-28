using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMT.Models
{
    class Order
    {
        public string Name { get; set; }
    }

    class OrderContect : DbContext
    {
        DbSet<Order> Orders { get; set; }
    }
}
