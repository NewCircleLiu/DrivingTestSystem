using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DrivingTestSystem.Models.Subject;

namespace DrivingTestSystem.Models.Subject
{
    public class SubjectContext : DbContext
    {
        public SubjectContext()
            : base("name=Subject-Context")
        { }

       public DbSet<Subject> SubjectList { get; set; }

    }
}