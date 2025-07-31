using CaseDataAccess.Dals.Abstract;
using CaseDataAccess.Dals.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDataAccess.DependencyInjection
{
    public class DataAccessServiceRegistration
    {
        public static void RegisterDataAccessServices(IServiceCollection services)
        {
            services.AddTransient<ITodoItemDal, TodoItemDal>();
            services.AddTransient<IUserDal, UserDal>();
        }
    }
}
