/*
 * Program:         GpaCalculatorLibrary.dll
 * Module:          Course.cs
 * Date:            April 15, 2021
 * Description:     Defines a Course class. An object of this class stores data for one one academic course.
 */

using System;
using System.Runtime.Serialization;

namespace GpaCalculatorLibrary
{
    [DataContract]
    public class Course
    {
        // ------------------------------------- Constructor -------------------------------------

        internal Course(string code, double creds, string letter)
        {
            Code = code.ToUpper();
            Credits = creds;
            LetterGrade = letter.ToUpper();

            // Determine grade point
            switch (letter)
            {
                case "A+": GradePoint = 4.2; break;
                case "A": GradePoint = 4.0; break;
                case "B+": GradePoint = 3.5; break;
                case "B": GradePoint = 3.0; break;
                case "C+": GradePoint = 2.5; break;
                case "C": GradePoint = 2.0; break;
                case "D+": GradePoint = 1.5; break;
                case "D": GradePoint = 1.0; break;
                case "F": default: GradePoint = 0.0; break;
            }
        }

        // ---------------------------------- Public Properties ----------------------------------
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public double Credits { get; set; }
        [DataMember]
        public string LetterGrade { get; set; }
        [DataMember]
        public double GradePoint { get; set; }

    } // end class Course
}
