using BlogDemo.Entities.ComplexTypes;
using BlogDemo.Entities.Concrete;
using DemoFramework.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemo.DataAccess.Abstract
{
  public  interface IUserDal:IEntityRepository<User>
    {
        List<UserRoleName> GetUserRoles(User user);
        void Close();
    }
}
