/**
 * Author:    Kenneth Salguero u1021533
 * Partner:   None
 * Date:      12/12/2021
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
 *    A class representing all the information needed for a Enrollment.
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TA_Application_MVC.Areas.Identity.Data;

namespace TA_Application_MVC.Models
{
    public class Enrollment
    {
        
        public int CourseID { get; set; }

        public DateTime date { get; set; }

        public int enrollmentNum { get; set; }

        // foreign key
        public virtual Course course { get; set; }
    }
}
