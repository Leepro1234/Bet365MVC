using Bet365Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace Bet365Project
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base("name=MySQLConn")
        {

        }
        public DbSet<Scoccer> scoccer{ get; set; }
    }
}