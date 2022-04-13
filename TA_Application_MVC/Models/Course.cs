/**
 * Author:    Kenneth Salguero u1021533
 * Partner:   None
 * Date:      10/25/2021
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and [Your Name(s)] - This work may not be copied for use in Academic Coursework.
 *
 * I, Kenneth Salguero, certify that I wrote this code from scratch and did 
 * not copy it in part or whole from another source.  Any references used 
 * in the completion of the assignment are cited in my README file and in
 * the appropriate method header.
 *
 * File Contents
 *
 *    A class representing all the information needed for a course.
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TA_Application_MVC.Models
{

    public enum Semester
    {
        FALL, SPRING, SUMMER
    }

    public enum Department
    {
        CS, CE, COMP
    }

    public class Course
    {
        
        
            
            public int CourseID { get; set; }
            public Semester? Semester { get; set; }
            public int Year { get; set; }
            public string CourseTitle { get; set; }
            public Department? Department { get; set; }
            public int CourseNumber { get; set; }
            public int Section { get; set; }
            public string Description { get; set; }
            public string ProfessorUnid { get; set; }
            public string ProfessorName { get; set; }
            public String TimeAndDateOffered { get; set; }
            public string Location { get; set; }
            public int CreditHours { get; set; }
            public int Enrollment { get; set; }
            public string Note { get; set; }        
    }
}
