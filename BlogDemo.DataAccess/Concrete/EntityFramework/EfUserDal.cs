using BlogDemo.DataAccess.Abstract;
using BlogDemo.DataAccess.Concrete.EntityFramework.Contexts;
using BlogDemo.Entities.ComplexTypes;
using BlogDemo.Entities.Concrete;
using DemoFramework.Core.CrossCuttingConcerns.Security.Web;
using DemoFramework.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepository<User, BlogDemoContext>, IUserDal
    {
        public void Close()
        {
            AuthenticationHelper.Disponse();
        }

        public List<UserRoleName> GetUserRoles(User user)
        {
            using (BlogDemoContext context = new BlogDemoContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles on ur.UserId equals user.Id
                             where ur.UserId == user.Id
                             select new UserRoleName { RoleName = r.Name };
                return result.ToList();
            }
        }
    }
}
