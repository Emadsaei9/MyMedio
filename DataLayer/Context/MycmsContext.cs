using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MycmsContext:DbContext
    {
        public DbSet<sickGroup> sickGroups { get; set; }

        public DbSet<Sick> Sick { get; set; }

        public DbSet<Documents> Documents { get; set; }

    }
}
