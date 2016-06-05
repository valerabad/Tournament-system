using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CreateHomePage.Models
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(string connectionCofig)
        {
            Database.Connection.ConnectionString = connectionCofig;
        }
        public DbSet<Player> Players { get; set; }

    }
}