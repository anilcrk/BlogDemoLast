using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDemo.Admin.WebUI.Models
{
    public class BlogViewModel
    {
        public List<Blog>  Blogs { get; set; }
        public Blog Blog { get; set; }
    }
}