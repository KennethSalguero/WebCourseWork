/**
 * Author:    Kenneth Salguero u1021533
 * Partner:   None
 * Date:      10/15/2021
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
 *    Represents a TAUser.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TA_Application_MVC.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TAUser class
    public class TAUser : IdentityUser
    {
        [Key]
        public string unID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        
    }
}
