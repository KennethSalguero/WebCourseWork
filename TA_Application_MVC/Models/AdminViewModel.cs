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
 *    Represents the information needed for admin view.
 */

/*
 *  This class was based on one from this tutorial series: 
 *  ASP.NET core tutorial for beginners
 *  https://www.youtube.com/playlist?list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TA_Application_MVC.Models
{
 
    // Model for listing and editing student roles
    public class AdminViewModel
    {
        public AdminViewModel()
        {
            Roles = new Dictionary<string, bool>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        public string unID { get; set; }


        // each AdminViewModel contains a dictionary with all
        // the roles and a bool that says if the user is that
        // Paticular.
        public Dictionary<string, bool> Roles { get; set; } 


    }
    
}
