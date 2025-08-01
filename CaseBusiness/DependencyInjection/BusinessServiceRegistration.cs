using CaseBusiness.Abstract;
using CaseBusiness.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseBusiness.DependencyInjection
{
    public class BusinessServiceRegistration
    {
        public static void RegisterBusinessServices(IServiceCollection services)
        {
            services.AddScoped<ITodoItemManager, TodoItemManager>();
            services.AddScoped<IUserManager, UserManager>();
        }
    }
}
