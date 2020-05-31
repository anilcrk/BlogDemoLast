using BlogDemo.Entities.ComplexTypes;
using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserEmailAndPassword(string email, string password);
        List<UserRoleName> GetUserRoles(User user);
        User GetByUserForId(int id);
        void AutClear();
        List<User> GetList();
    }
}
