using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DB_BookPhone.Models.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("defaultConnection")
        {

        }
        public DbSet<Abonent> Abonents { get; set; }
    }
}