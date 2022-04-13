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
 *    The controller for the administrator.
 */

/*
 *  This class was made with the help of this tutorial series: 
 *  ASP.NET core tutorial for beginners
 *  https://www.youtube.com/playlist?list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU

 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TA_Application_MVC.Areas.Identity.Data;
using TA_Application_MVC.Data;
using TA_Application_MVC.Models;

[Authorize(Roles = "Administrator")]
public class AdministratorController : Controller
{
    private readonly RoleManager<IdentityRole> roleManager; // how we access role from db
    private readonly UserManager<TAUser> userManager;       // how we access users
    private readonly TA_DB _context;

    public AdministratorController(RoleManager<IdentityRole> roleManager,
                                    UserManager<TAUser> userManager, TA_DB context)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
        _context = context;
    }

    // I used this tutorial a guide to build the code below
    // ASP.NET core tutorial for beginners
    // https://www.youtube.com/playlist?list=PL6n9fhu94yhVkdrusLaQsfERmL_Jh4XmU
    [HttpGet]
    public async Task<IActionResult> Admin()
    {
        List<AdminViewModel> model = new List<AdminViewModel>();

        foreach (var user in userManager.Users)                         // For each user
        {
            AdminViewModel addStudent = new AdminViewModel();
            addStudent.Id = user.Id;
            addStudent.Name = user.FirstName + " " + user.LastName;
            addStudent.unID = user.unID;
       

            // adding the list of roles to the AdminViewModel           // Keeps track of the roles the user has
            foreach (var role in roleManager.Roles)                     // for each role that the user MAY have
            {
                if (await userManager.IsInRoleAsync(user, role.Name))   // if the user has the role
                {
                    addStudent.Roles.Add(role.Name, true);              // Add the role to the role list in the model
                }
                else
                {
                    addStudent.Roles.Add(role.Name, false);             // false if not the role
                }
            }
            model.Add(addStudent);                                      // Add the student with all the revelent info the the list
        }
        return View(model);                                             // Return the view with the model
    }

    [HttpPost]
    public async Task<IActionResult> OnCheckBoxClick(List<AdminViewModel> model)
    {
        // Since we cant update the database in a forloop we need to make an
        // array to iterate over.
        string[] rolesArray = model[0].Roles.Keys.ToArray();    

        // Go through all the users
        for (int i = 0; i < model.Count; i++) 
        {
            var user = await userManager.FindByIdAsync(model[i].Id);
       
            // For each user update all the roles
            for (int j = 0; j < rolesArray.Length; j++)
            {
                // if user is selected for roll and isnt a member of the role add him to role
                if (model[i].Roles[rolesArray[j]] && !(await userManager.IsInRoleAsync(user, rolesArray[j])))   
                {
                    await userManager.AddToRoleAsync(user, rolesArray[j]);
                }
                // Remove user from role
                else if (!model[i].Roles[rolesArray[j]] && (await userManager.IsInRoleAsync(user, rolesArray[j]))) 
                {
                    await userManager.RemoveFromRoleAsync(user, rolesArray[j]);
                }
            }          
        }
        return View("Admin", model);
    }


    // GET: Enrollments
    public async Task<IActionResult> EnrollmentTrends()
    {
        var tA_DB = _context.Course;
        return View(await tA_DB.ToListAsync());
    }


    [HttpPost]
    public async Task<String> GetEnrollmentData(string dep, string cNum, string startDate)
    {
        // Get the date and course num.
        int cnum = int.Parse(cNum);
        DateTime date = DateTime.Parse(startDate);



        // Lookup the course       
        Course lookupCouse = _context.Course.Where(c => c.CourseNumber == cnum).FirstOrDefault();

        dep.Equals(lookupCouse.Department.ToString());

        // Find all the enrollments with the same course and after the date
        var enrollList = _context.Enrollment.Where(c => c.CourseID == lookupCouse.CourseID && c.date >= date);

        // Store it in list (sort beforehand)
        List<int> dataToSend = new List<int>();
        enrollList.OrderBy(c => c.date);
        foreach (Enrollment e in enrollList)
        {
            dataToSend.Add(e.enrollmentNum);
        }

        // Send to the data back.
        string jsonString = JsonSerializer.Serialize(dataToSend);

        return jsonString;


    }
}
   