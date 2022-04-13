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
 *    Initializes the database with new values.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TA_Application_MVC.Models;
using TA_Application_MVC.Areas.Identity.Data;
using System.IO;

namespace TA_Application_MVC.Data
{
    public class TA_DB_Initializer
    {
        public static void Initialize(TA_DB context)
        {
            context.Database.EnsureCreated();

            if (context.Applications.Any() && context.Course.Any())
            {
                return;   // DB has been seeded
            }

            var applications = new Application[]
            {
                new Application{StudentuID=1, CreationDate=DateTime.Now, ModificationDate=DateTime.Now, PersonalStatement="I like CS.", RequestedHours=10, 
                    ResumeFileUpload="",  LinkedInURL="www.Website.com/1",FirstMidName="u0000001@utah.edu",LastName=".",PhoneNumber="801-555-5551", GPA=4.0,Address="101 Main St.",
                    SemestersCompleted=3,Degree=Degree.BS,Major=Major.CS },
                new Application{StudentuID=2, CreationDate=DateTime.Now, ModificationDate=DateTime.Now, PersonalStatement="Im a good tutor.", RequestedHours=5,
                    ResumeFileUpload="",  LinkedInURL="www.Website.com/2",FirstMidName="u0000002@utah.edu",LastName=".",PhoneNumber="801-222-5551", GPA=3.1,Address="102 Main St.",
                    SemestersCompleted=3,Degree=Degree.BS,Major=Major.CS },
            };

            foreach (Application a in applications)
            {
                context.Applications.Add(a);
            }
            context.SaveChanges();

        
            
            var courses = new Course[]
            {
                
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Introduction to Computer Programming",
                    Department=Department.CS, CourseNumber=1400, Section=001, Description="Learn the foundations of programming",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="MoWe/3:00-5:00",Location="MEB123",
                    CreditHours=3, Enrollment=33, Note="Get more students into this class"
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Introduction to Object-Oriented Programming",
                    Department=Department.CS, CourseNumber=1410, Section=001, Description="",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="MoWe/3:00-5:00",Location="MEB123",
                    CreditHours=3, Enrollment=33, Note="Get more students into this class"
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Accel Obj-Orient Prog",
                    Department=Department.CS, CourseNumber=1420, Section=001, Description="",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="MoWe/3:00-5:00",Location="MEB123",
                    CreditHours=3, Enrollment=33, Note="Get more students into this class"
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Descrete Math",
                    Department=Department.CS, CourseNumber=2100, Section=001, Description="A deep dive into the mathmatical logic of computing.",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="We/9:00-11:00",Location="MEB100",
                    CreditHours=3, Enrollment=20, Note=""
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Intro to Algorithms",
                    Department=Department.CS, CourseNumber=2420, Section=001, Description="Detailed information of Algorithms",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="Fr/1:00-2:00",Location="MEB200",
                    CreditHours=3, Enrollment=100, Note=""
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Models of Computation",
                    Department=Department.CS, CourseNumber=3100, Section=001, Description="",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="Fr/1:00-2:00",Location="MEB200",
                    CreditHours=3, Enrollment=100, Note=""
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Introduction to Scientific Computing",
                    Department=Department.CS, CourseNumber=3200, Section=001, Description="",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="Fr/1:00-2:00",Location="MEB200",
                    CreditHours=3, Enrollment=100, Note=""
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Software Practice",
                    Department=Department.CS, CourseNumber=3500, Section=001, Description="",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="Fr/1:00-2:00",Location="MEB200",
                    CreditHours=3, Enrollment=100, Note=""
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Algorithms",
                    Department=Department.CS, CourseNumber=4150, Section=001, Description="",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="Fr/1:00-2:00",Location="MEB200",
                    CreditHours=3, Enrollment=100, Note=""
                    },

                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Computer Systems",
                    Department=Department.CS, CourseNumber=4400, Section=001, Description="Learning the fundementals of computer hardware and software interaction.",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="TuTh/1:00-2:00",Location="MEB231",
                    CreditHours=3, Enrollment=57, Note="This is a hard class"
                    },

                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Networking",
                    Department=Department.CS, CourseNumber=4480, Section=001, Description="Learn about networking",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="TuTh/1:00-2:00",Location="MEB300",
                    CreditHours=3, Enrollment=200, Note=""
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Capstone",
                    Department=Department.CS, CourseNumber=4500, Section=001, Description="",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="Fr/1:00-2:00",Location="MEB200",
                    CreditHours=3, Enrollment=100, Note=""
                    },
                new Course{Semester=Semester.SPRING, Year=2021, CourseTitle = "Modbile Application Programing",
                    Department=Department.CS, CourseNumber=4530, Section=001, Description="",
                    ProfessorUnid = "u0000005", ProfessorName="Professor", TimeAndDateOffered ="Fr/1:00-2:00",Location="MEB200",
                    CreditHours=3, Enrollment=100, Note=""
                    },
            };





            foreach (Course c in courses)
            {
                context.Course.Add(c);
            }
            context.SaveChanges();
           
            

            var available = new Availability[]
            {
                new Availability{unID="u0000000", timeSlot="Monday 8", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 8.25", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 8.5", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 8.75", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 9", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 9.25", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 9.5", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 9.75", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 10", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 10.25", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 10.5", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 10.75", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 11", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 11.25", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 11.5", open = false},
                new Availability{unID="u0000000", timeSlot="Monday 11.75", open = false},

                new Availability{unID="u0000000", timeSlot="Friday 8", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 8.25", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 8.5", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 8.75", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 9", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 9.25", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 9.5", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 9.75", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 10", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 10.25", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 10.5", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 10.75", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 11", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 11.25", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 11.5", open = false},
                new Availability{unID="u0000000", timeSlot="Friday 11.75", open = false},

                new Availability{unID="u0000000", timeSlot="Tuesday 12", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 12.25", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 12.5", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 12.75", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 13", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 13.25", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 13.5", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 13.75", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 14", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 14.25", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 14.5", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 14.75", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 15", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 15.25", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 15.5", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 15.75", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 16", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 16.25", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 16.5", open = false},
                new Availability{unID="u0000000", timeSlot="Tuesday 16.75", open = false},

                new Availability{unID="u0000000", timeSlot="Thursday 12", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 12.25", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 12.5", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 12.75", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 13", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 13.25", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 13.5", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 13.75", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 14", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 14.25", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 14.5", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 14.75", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 15", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 15.25", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 15.5", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 15.75", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 16", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 16.25", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 16.5", open = false},
                new Availability{unID="u0000000", timeSlot="Thursday 16.75", open = false},



            };

            foreach (Availability a in available)
            {
                context.Availability.Add(a);
            }
            context.SaveChanges();


            List<Enrollment> enrollments = new List<Enrollment>();
            List<string[]> csvFile = new List<string[]>();

            using (var reader = new StreamReader(@"wwwroot\EnrollmentFiles\temp.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var data = reader.ReadLine().Split(',');
                    csvFile.Add(data);
                }

                DateTime[] datesArray = new DateTime[csvFile[0].Length]; // for easily converting dates intead of parsing each time
                for (int i = 1; i < datesArray.Length; i++) // Start at 1 for consistancy
                {
                    datesArray[i] = DateTime.Parse(csvFile[0][i] + " 2021");
                }

                
                
                for (int i = 1; i < csvFile.Count; i++)
                {
                    int cnum = int.Parse(csvFile[i][0].Split(' ')[1]);
                    Course addCourse = context.Course.Where(c => c.CourseNumber == cnum).FirstOrDefault();
                    for (int j = 1; j < datesArray.Length; j++)
                    {
                        Enrollment e = new Enrollment { CourseID = addCourse.CourseID, date = datesArray[j], enrollmentNum = int.Parse(csvFile[i][j]) };
                        enrollments.Add(e);                        
                    }
                }
            }

            foreach (Enrollment e in enrollments)
            {
                context.Enrollment.Add(e);
            }
            context.SaveChanges();
        }
    }
}
