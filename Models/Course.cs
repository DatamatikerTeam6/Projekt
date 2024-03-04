using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace HundeProjekt.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseDate { get; set; }

        //Navigationproperties        
       //User is missing    
        RuleSet Ruleset { get; set; }
        public List<Exercise> Exercises { get; } = [];
        public List<CourseExercise> CourseExercises { get; } = [];  
    }
}
