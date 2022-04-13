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
 *    This class seeds the database with roles and users.
 */
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TA_Application_MVC.Areas.Identity.Data;
using TA_Application_MVC.Data;

namespace TA_Application_MVC.Areas.Identity
{
    public static class SeedUserRolesDB
    {
        public static async Task InitializeAsync(TAUsersRolesDB db,
            UserManager<TAUser> um,
            RoleManager<IdentityRole> rm)
        {

            db.Database.EnsureCreated();

            if (db.Users.Count() != 0)
            {
                return;   // DB has been seeded
            }

            // Create the roles
            string[] roles = { "Administrator", "Professor", "Applicant" };

            for (int i = 0; i < roles.Length; i++)
            {
                await rm.CreateAsync(new IdentityRole(roles[i]));
            }

            // Create the users
            string[] usersName = {"u0000000@utah.edu", 
                "u0000001@utah.edu", "u0000002@utah.edu", "admin@utah.edu", "professor@utah.edu" };
            for (int i = 0; i < usersName.Length; i++)
            {
                var user = new TAUser { UserName = usersName[i], Email = usersName[i], FirstName = usersName[i], LastName = "", EmailConfirmed = true, LockoutEnabled = false, unID = "u" + i.ToString().PadLeft(8 - i.ToString().Length, '0') };
                await um.CreateAsync(user, "123ABC!@#def");
                if(usersName[i] == "admin@utah.edu") await um.AddToRoleAsync(user, "Administrator");
                else if (usersName[i] == "professor@utah.edu") await um.AddToRoleAsync(user, "Professor");
                else await um.AddToRoleAsync(user, "Applicant");
            }        
        }
    }
}
