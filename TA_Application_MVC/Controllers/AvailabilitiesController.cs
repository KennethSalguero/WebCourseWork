/**
 * Author:    Kenneth Salguero u1021533
 * Partner:   None
 * Date:      11/22/2021
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
 *    The controller for the availability application.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TA_Application_MVC.Areas.Identity.Data;
using TA_Application_MVC.Data;

namespace TA_Application_MVC.Models
{
    [Authorize]
    public class AvailabilitiesController : Controller
    {
        private readonly TA_DB _context;
        private readonly RoleManager<IdentityRole> roleManager; // how we access role from db
        private readonly UserManager<TAUser> userManager;       // how we access users

        public AvailabilitiesController(TA_DB context, RoleManager<IdentityRole> roleManager,
                                    UserManager<TAUser> userManager)
        {
            _context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;

        }

        // GET: Availabilities
        public IActionResult Index()
        {                     
            return View();
        }

        [HttpGet]
        public async Task<string> GetSchedule()
        {
            // https://stackoverflow.com/questions/38751616/asp-net-core-identity-get-current-user
            // Get unID
            var currentUser = await userManager.GetUserAsync(User);
            string currentUserUnid = currentUser.unID;

            var availability = _context.Availability;

            List<string> availableList = new List<string>();

            // Pass unid and list of available times to AvailabilityTracker
            availableList.Add(currentUserUnid);
           
            foreach (var a in availability)
            {
                if (a.unID == currentUserUnid)
                {
                    availableList.Add(a.timeSlot);
                }
            }

            string jsonString = JsonSerializer.Serialize(availableList);

            return jsonString;
        }

        [HttpPost]
        public async Task<String> SetScheduleAsync(string availability, string day, string hour, string unId) 
        {
            bool available = Boolean.Parse(availability);
            string timeslot = day + " " + hour;

            
            Availability a = new Availability();
            a.unID = unId;
            a.timeSlot = timeslot;

            if (ModelState.IsValid)
            {
                if (a != null)
                {
                    // If available add it to database.
                    if (available)
                    {
                        _context.Add(a);
                        await _context.SaveChangesAsync();
                    }
                    // Else remove the item.
                    else
                    {
                        _context.Availability.Remove(a);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return "";
        }         
    }
}
