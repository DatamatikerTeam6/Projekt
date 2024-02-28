using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HundeProjekt.Data;
using HundeProjekt.Models;
using System;
using System.Linq;
using HundeProjekt.Controllers;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HundeProjektContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HundeProjektContext>>()))
            {
                // Look for any movies.
                if (context.Exercises.Any())
                {
                    return;   // DB has been seeded
                }

                context.Exercises.AddRange(
                    new Exercise
                    {
                        Description = "Moder øvelsen",                     
                        MovementEnumID = MovementEnum.Stationær,         
                        Sideshift = true, 
                        IllustrationPath = "/images/exercises/Moderen.png",
                        ClassEnumID = ClassEnum.Begynder, 
                        SignNumber = 1, 
                        PositionX = 10,
                        PositionY = 75
                        
                    },

                    new Exercise
                    {
                        Description = "Emretrix",
                        MovementEnumID = MovementEnum.Gang,
                        Sideshift = false,
                        IllustrationPath = "/images/exercises/Emretrix.png",
                        ClassEnumID = ClassEnum.Begynder,
                        SignNumber = 2,
                        PositionX = 10,
                        PositionY = 10
                    }              
                );
                context.SaveChanges();
            }
        }
    }
}