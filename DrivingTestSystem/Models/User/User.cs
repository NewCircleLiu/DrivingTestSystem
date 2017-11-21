using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DrivingTestSystem.Models.User
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string user_account { get; set; }
        public string user_password { get; set; }
        public string user_img { get; set; }
    }
}