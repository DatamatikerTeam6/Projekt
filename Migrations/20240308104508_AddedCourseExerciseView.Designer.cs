﻿// <auto-generated />
using System;
using HundeProjekt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HundeProjekt.Migrations
{
    [DbContext(typeof(HundeProjektContext))]
    [Migration("20240308104508_AddedCourseExerciseView")]
    partial class AddedCourseExerciseView
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HundeProjekt.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<DateTime>("CourseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseID");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("HundeProjekt.Models.CourseExercise", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<int?>("CourseID1")
                        .HasColumnType("int");

                    b.Property<double>("PositionX")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("PositionY")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.HasKey("CourseID", "ExerciseID");

                    b.HasIndex("CourseID1");

                    b.HasIndex("ExerciseID");

                    b.ToTable("CourseExercise", (string)null);

                    b.ToView("HPCourseExerciseView", (string)null);
                });

            modelBuilder.Entity("HundeProjekt.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExerciseID"));

                    b.Property<int>("ClassEnumID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IllustrationPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovementEnumID")
                        .HasColumnType("int");

                    b.Property<double>("PositionX")
                        .HasColumnType("float");

                    b.Property<double>("PositionY")
                        .HasColumnType("float");

                    b.Property<bool>("Sideshift")
                        .HasColumnType("bit");

                    b.Property<int>("SignNumber")
                        .HasColumnType("int");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercise", (string)null);
                });

            modelBuilder.Entity("HundeProjekt.Models.Ruleset", b =>
                {
                    b.Property<int>("RulesetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RulesetID"));

                    b.Property<int>("NumberOfBeginner")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChampion")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfConeExercises")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDoubleJumpExercises")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfExercises")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfExpert")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfIntermediate")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfJumpExercises")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfReverseExercises")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRightActs")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSingleJumpExercises")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfStationary")
                        .HasColumnType("int");

                    b.Property<int>("RulesetClass")
                        .HasColumnType("int");

                    b.HasKey("RulesetID");

                    b.ToTable("Ruleset", (string)null);
                });

            modelBuilder.Entity("HundeProjekt.Models.CourseExercise", b =>
                {
                    b.HasOne("HundeProjekt.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HundeProjekt.Models.Course", null)
                        .WithMany("CourseExercises")
                        .HasForeignKey("CourseID1");

                    b.HasOne("HundeProjekt.Models.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExerciseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HundeProjekt.Models.Course", b =>
                {
                    b.Navigation("CourseExercises");
                });
#pragma warning restore 612, 618
        }
    }
}
