
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Data
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           System.Reflection.Assembly assembly = typeof(AppDbContext).Assembly;
            ;

            optionsBuilder.UseSqlite("FileName=challengedb", option =>
            {
                var assem = System.Reflection.Assembly.GetExecutingAssembly();
                option.MigrationsAssembly(assem.FullName);
            });
            base.OnConfiguring(optionsBuilder);        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
        
        }

    }
}
