using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HundeProjekt.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HundeProjekt.Data
{
    public class HundeProjektContext : DbContext
    {
        public HundeProjektContext(DbContextOptions<HundeProjektContext> options)
            : base(options)
        {
        }

        public DbSet<HundeProjekt.Models.Exercise> Exercises { get; set; } = default!;
        public DbSet<HundeProjekt.Models.Ruleset> Rulesets { get; set; } = default!;
        public DbSet<HundeProjekt.Models.Course> Courses { get; set; } = default!;
        public DbSet<HundeProjekt.Models.CourseExercise> CourseExerciseView { get; set; } = default!;





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<Ruleset>().ToTable("Ruleset");
            modelBuilder.Entity<Course>().ToTable("Course");            

            modelBuilder.Entity<Course>()
        .HasMany(c => c.Exercises)
        .WithMany(e => e.Courses)
        .UsingEntity<CourseExercise>(
            j => j
                .HasOne<Exercise>()
                .WithMany()
                .HasForeignKey(ce => ce.ExerciseID),
            j => j
                .HasOne<Course>()
                .WithMany()
                .HasForeignKey(ce => ce.CourseID),
            j =>
            {
                j.Property(ce => ce.PositionX).HasDefaultValue(0); // Standardværdi kan justeres efter behov
                j.Property(ce => ce.PositionY).HasDefaultValue(0); // Standardværdi kan justeres efter behov
                j.HasKey(ce => new { ce.CourseID, ce.ExerciseID }); // Definerer sammensat primær nøgle
                j.ToTable("CourseExercise"); // Specificerer navnet på join-tabellen
            });


            //Get data from view
            modelBuilder.Entity<CourseExercise>().ToView("HPCourseExerciseView6");
        }

    }







}