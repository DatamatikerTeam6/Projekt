using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HundeProjekt.Models;

namespace HundeProjekt.Data
{
    public class HundeProjektContext : DbContext
    {
        public HundeProjektContext (DbContextOptions<HundeProjektContext> options)
            : base(options)
        {
        }

        public DbSet<HundeProjekt.Models.Exercise> Exercises { get; set; } = default!;
        public DbSet<HundeProjekt.Models.Ruleset> Rulesets { get; set; } = default!;
        public DbSet<HundeProjekt.Models.Course> Courses { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<Ruleset>().ToTable("Ruleset");
            modelBuilder.Entity<Course>().ToTable("Course");
        }
     


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Exercise>()
        //        .Property(e => e.ClassEnumID)
        //        .HasColumnName("ClassEnumID");
        //}



    }
}
