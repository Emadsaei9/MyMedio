using MyMedio.Models.Karbar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DataLayer
{
    public class Mycontext:DbContext
    {
        public DbSet<Sick> Sicks { get; set; }

        public DbSet <Documents> Documents { get; set; }

        public DbSet<SickGroup> SickGroups { get; set; }
        
        public DbSet<Karbar> Karbars { get; set; }

    }
}
