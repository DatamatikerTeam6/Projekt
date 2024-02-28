﻿namespace HundeProjekt.Models
{
    public class Exercise
    {
        // Declaration of public properties

        public int ExerciseID {  get; set; }
        public string Description { get; set; }
        public MovementEnum MovementEnumID { get; set; }
        public bool Sideshift { get; set; }
        public string IllustrationPath { get; set; }
        public ClassEnum ClassEnumID { get; set; }
        public int SignNumber { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        //Navigationproperties
        Course Course { get; set; }
    }
}
