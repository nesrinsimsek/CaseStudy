using CaseBusiness.Abstract;
using CaseDataAccess.Dals.Abstract;
using CaseDataAccess.Dals.Concrete;
using CaseDataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseBusiness.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<User> GetUserById(int userId)
        {
            return await _userDal.Get(u => u.Id == userId);
        }

        public async Task<List<User>> GetUserList()
        {
            return await _userDal.GetList();
        }
    }
}
