using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BallisticModel
{
    public class BallisticContext : DbContext
    {
        public DbSet<Firearm> Firearms { get; set; }
        public DbSet<FirearmType> FirearmTypes { get; set; }
        public DbSet<Ammunition> Ammunition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Ballistic;");
    }

  
}
