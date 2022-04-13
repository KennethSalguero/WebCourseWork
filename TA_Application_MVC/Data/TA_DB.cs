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
 *    The Database.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TA_Application_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace TA_Application_MVC.Data
{
    public class TA_DB : DbContext
    {
        public TA_DB(DbContextOptions<TA_DB> options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Course> Course { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>().ToTable("Applications");


            modelBuilder.Entity<Course>().ToTable("Course");


            modelBuilder.Entity<Availability>()               
                .HasKey(a => new { a.unID, a.timeSlot });

            modelBuilder.Entity<Enrollment>()
                .HasKey(a => new { a.CourseID, a.date });
        }


        public DbSet<TA_Application_MVC.Models.Availability> Availability { get; set; }


        public DbSet<TA_Application_MVC.Models.Enrollment> Enrollment { get; set; }
    }
}
