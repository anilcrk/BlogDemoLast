using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDemo.WebUI.Models
{
    public class IndexViewModel
    {
        public List<User> Users { get; set; }
    }
}