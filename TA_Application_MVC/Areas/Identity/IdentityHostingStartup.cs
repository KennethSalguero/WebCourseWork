using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
 *    This configures the database.
 */

using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TA_Application_MVC.Areas.Identity.Data;
using TA_Application_MVC.Data;

[assembly: HostingStartup(typeof(TA_Application_MVC.Areas.Identity.IdentityHostingStartup))]
namespace TA_Application_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TAUsersRolesDB>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TAUsersRolesDBConnection")));

                services.AddDefaultIdentity<TAUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TAUsersRolesDB>();                                  
            });
        }
    }
}