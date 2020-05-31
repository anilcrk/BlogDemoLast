using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDemo.WebUI.Models
{
    public class DetailViewModel
    {
       public User User { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}