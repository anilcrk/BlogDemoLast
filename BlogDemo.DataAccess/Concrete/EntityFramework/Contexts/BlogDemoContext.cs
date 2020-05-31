using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.DataAccess.Concrete.EntityFramework.Contexts
{
   public class BlogDemoContext:DbContext
    {
        public BlogDemoContext()
        {
            Database.SetInitializer<BlogDemoContext>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }
}
