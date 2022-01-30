
using Challenge.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<student_record> student_records { get; set; }
        public DbSet<class_record> class_records { get; set; }
        public DbSet<country_record> country_records { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           System.Reflection.Assembly assembly = typeof(AppDbContext).Assembly;
            ;

            optionsBuilder.UseSqlite("FileName=challengedb.db", option =>
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
