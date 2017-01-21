//DataBase access connection.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//add the below line:
using System.Data.Entity;

namespace MvcLoginReg.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}