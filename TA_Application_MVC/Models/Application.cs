/**
 * Author:    Kenneth Salguero u1021533
 * Partner:   None
 * Date:      9/28/2021
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
 *    A class representing all the information needed for a application.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TA_Application_MVC.Models
{

    public enum Degree
    {
        BA, BS, MA, MS
    }

    public enum Major
    {
        CS, CE, ME
    }
    public class Application
    {
        public int ID { get; set; }

        public int RequestedHours { get; set; }

        public string LinkedInURL { get; set; }

        public string ResumeFileUpload { get; set; }

        public string PersonalStatement { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }


        public int StudentuID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string PhoneNumber { get; set; }
        public double GPA { get; set; }
        public string Address { get; set; }
        public int SemestersCompleted { get; set; }
        public Degree? Degree { get; set; }
        public Major? Major { get; set; }

    }
}