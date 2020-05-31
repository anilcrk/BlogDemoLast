using BlogDemo.Business.Abstract;
using BlogDemo.DataAccess.Abstract;
using BlogDemo.DataAccess.Concrete.EntityFramework.Contexts;
using BlogDemo.Entities.ComplexTypes;
using BlogDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AutClear()
        {
            _userDal.Close();
        }

        public User GetByUserEmailAndPassword(string email, string password)
        {
            return _userDal.Get(u => u.Email == email && u.Password == password);
        }

        public User GetByUserForId(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        public List<User> GetList()
        {
            return _userDal.GetList();
        }

        public List<UserRoleName> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user).ToList();
        }
    }
}
