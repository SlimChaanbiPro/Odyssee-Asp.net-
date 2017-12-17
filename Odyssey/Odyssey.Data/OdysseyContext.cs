using Odyssey.Data.Configuration;
using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Data
{
    public class OdysseyContext : DbContext
    {
        public OdysseyContext()
            : base("Odyssey")
        {
            Database.SetInitializer<OdysseyContext>(new OdysseyContextInitializer());
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
