using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDemo.Admin.WebUI.Models
{
    public class LoginModel
    {
        public User User { get; set; }
        public bool RememberMe { get; set; }
    }
}