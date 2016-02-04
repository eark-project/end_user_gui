using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace end_user_gui.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<Archivist> Archivists { get; set; }

        public System.Data.Entity.DbSet<end_user_gui.Models.OrderArchiveReference> OrderArchiveReferences { get; set; }
    }
}
