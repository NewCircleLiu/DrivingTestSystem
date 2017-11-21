﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DrivingTestSystem.Models.User;

namespace DrivingTestSystem.Models.User
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("name=User-Context")
        { }

       public DbSet<User> UserList { get; set; }
    }
}