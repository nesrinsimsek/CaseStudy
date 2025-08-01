using CaseStudyMVC.Common;
using CaseStudyMVC.Services.Abstract;
using CaseStudyMVC.Utility;

namespace CaseStudyMVC.Services.Concrete
{
    public class UserService : BaseService, IUserService
    {
        private string userApiUrl;
        public UserService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            userApiUrl = "https://localhost:7248";
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                HttpMethodType = ApiHttpMethod.MethodType.GET,
                Url = userApiUrl + "/api/users"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                HttpMethodType = ApiHttpMethod.MethodType.GET,
                Url = userApiUrl + "/api/users/" + id

            });
        }
    }
}
