using CaseDataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseBusiness.Abstract
{
    public interface IUserManager
    {
        Task<User> GetUserById(int userId);
        Task<List<User>> GetUserList();
    }
}
