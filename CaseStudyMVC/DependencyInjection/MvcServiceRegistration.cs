using CaseStudyMVC.Services.Abstract;
using CaseStudyMVC.Services.Concrete;

namespace CaseStudyMVC.DependencyInjection
{
    public class MvcServiceRegistration
    {
        public static void RegisterMvcServices(IServiceCollection services)
        {
            services.AddScoped<ITodoItemService, TodoItemService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
