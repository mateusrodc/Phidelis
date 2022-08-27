using Back.PhidelisSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.PhidelisSystem.Infra.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }
        public bool IgnoreSaveChangeAndUseTransaction { get; set; }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        //public DbSet<Registration> Registration { get; set; }
        

        public override int SaveChanges()
        {
            if (!IgnoreSaveChangeAndUseTransaction)
                return base.SaveChanges();
            return 0;
        }
    }
}
