/*
 * Program:         GpaCalculatorLibrary.dll
 * Module:          Gpa.cs
 * Date:            April 15, 2021
 * Description:     Defines a Gpa class that calculates the grade point average for a set of courses.
 * 
 * IMPORTANT:       DO NOT REMOVE ANY CODE THAT GENERATES CONSOLE OUTPUT! THIS WILL BE USED FOR 
 *                  EVALUATING YOUR SOLUTION.
 */
/*
 * Project: Final Practical WPF
 * Purpose: Demonstrate learning and understanding of WPF
 * Coder: Sonia Friesen, 0813682        
 * Date: April 19th 2021
 */
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GpaCalculatorLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Gpa:IGpa
    {
        // --------------------------------- Private Member Data ---------------------------------

        private List<Course> courses = null;
        private static uint objCount = 0;
        private uint objId;

        // ------------------------------------- Constructor -------------------------------------

        public Gpa()
        {
            objId = ++objCount;
            Console.WriteLine($"Gpa #{objId} created.");
            courses = new List<Course>();
        }

        // ------------------------------ Public Methods/Properties ------------------------------

        // Read/write property that stores a student name as a string
        public string Student
        {
            get; set;
        }

        // Accepts course code, credits and letter grade and returns an initialized Course object
        public Course AddCourse(string code, double credits, string letter)
        {
            Console.WriteLine($"Gpa #{objId} adding course '{code}' with letter grade {letter} worth {credits} credit(s).");
            Course course = new Course(code, credits, letter);
            courses.Add(course);
            return course;
        }

        // Read-only property that represents the number of courses added 
        public int CourseCount
        {
            get => courses.Count;
        }

        // Returns the total credits earned for each Course added with a letter grade better than F
        public double CalcCredits()
        {
            double cred = 0;
            foreach (Course c in courses)
                cred += c.GradePoint > 0 ? c.Credits : 0;
            return cred;
        }

        // Returns the GPA for all courses added
        public double CalcGpa()
        {
            double points = 0, credits = 0;

            foreach (Course c in courses)
            {
                points += c.GradePoint * c.Credits;
                credits += c.Credits;
            }

            if (CalcCredits() > 0)
                return points / credits;

            return 0;
        }

    } // end class Gpa
}
