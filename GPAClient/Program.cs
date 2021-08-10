/*
 * Program:         GpaCalculatorClient.exe
 * Module:          Program.cs
 * Date:            April 15, 2021
 * Description:     Console client to calculate a student's GPA using GpaCalculatorLibrary.dll.
 */

/*
 * Project: Final Practical WPF
 * Purpose: Demonstrate learning and understanding of WPF
 * Coder: Sonia Friesen, 0813682        
 * Date: April 19th 2021
 */
using GpaCalculatorLibrary;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace GpaCalculatorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IGpa gpa = null;
            try
            {
                //connect to end point
                ChannelFactory<IGpa> channel = new ChannelFactory<IGpa>("GameEndPoint");
                gpa = channel.CreateChannel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Display a title
            string title = "        Student GPA Calculation         ";
            printLine(title.Length);
            Console.WriteLine(title);
            printLine(title.Length);

            // Create a service GpaCalculatorLibrary.Gpa object            
            gpa.Student = getUserTextData("Enter the student's name", null);

            // Obtain data for each course and display a summary
            string status;
            StringBuilder report = new StringBuilder();
            Console.WriteLine("\nNow enter information for each course...");
            do
            {
                Console.WriteLine();

                // Inputs
                string code = getUserTextData("Code", null);
                double credits = getUserRealData("Credits", 0, 5);
                string letterGrade = getUserTextData("Letter Grade", LETTER_GRADES);

                // Add course
                Course course = gpa.AddCourse(code, credits, letterGrade);

                // Append course data to a report for the semester
                report.Append(String.Format("{0,-13} {1,8:0.00} {2,8} {3,8:0.0}\n", course.Code,
                    course.Credits, course.LetterGrade, course.GradePoint));

                Console.Write("\nPress ENTER to add another course or type \"done\" to finish: ");
                status = Console.ReadLine().ToLower();
            } while (status != "done");

            
            // Report the GPA results
            Console.WriteLine($"\nGPA report for {gpa.Student} based on the {gpa.CourseCount} course(s) entered...\n");
            printLabels();
            printLine(40);
            Console.Write(report.ToString());
            printLine(40);
            Console.WriteLine("{0,-13} {1,8:0.00} {2,8} {3,8:0.0}", "Totals",
                    gpa.CalcCredits(), "-", gpa.CalcGpa());

            // Wait for keystroke to end
            Console.WriteLine("\nHit any key to close.");
            Console.ReadKey();

        } // end Main()

        #region helper_code

        private static readonly List<string> LETTER_GRADES = new List<string>() { "A+", "A", "B+", "B", "C+", "C", "D+", "D", "F" };

        // Obtains string input from the user that must match one of the validValues
        private static string getUserTextData(string prompt, List<string> validValues)
        {
            string input;
            bool validInput;
            do
            {
                Console.Write(prompt + ": ");
                input = Console.ReadLine().ToUpper();
                if (!(validInput = (validValues == null ? input.Length > 0 : validValues.Contains(input))))
                    Console.WriteLine("ERROR: Input provided isn't an expected value.");
            } while (!validInput);
            return input;
        } // end getUserTextData()

        // Obtains a real number between min and max (inclusive) from the user 
        private static double getUserRealData(string prompt, double min, double max)
        {
            string input;
            double value;
            bool validInput;
            do
            {
                Console.Write(prompt + ": ");
                input = Console.ReadLine();
                if (!(validInput = double.TryParse(input, out value) && value >= min && value <= max))
                    Console.WriteLine($"ERROR: Input must be a number between {min} and {max} (inclusive).");
            } while (!validInput);
            return value;
        } // end getUserRealData()

        // Prints column labels for the report table
        private static void printLabels()
        {
            Console.WriteLine("{0,-13} {1,8} {2,8} {3,8}",
                "Course", "Credits", "Grade", "GP/GPA");
        } // end printLabels()

        // Prints a horizontal line of "length" hyphens
        private static void printLine(int length)
        {
            string line = new string('-', length);
            Console.WriteLine(line);
        } // end printLine();

        #endregion

    } // end class Program
}
