using CaseStudyMVC.Common;
using CaseStudyMVC.Dtos;
using CaseStudyMVC.Services.Abstract;
using CaseStudyMVC.Utility;

namespace CaseStudyMVC.Services.Concrete
{
    public class TodoItemService : BaseService, ITodoItemService
    {
        private string todoItemApiUrl;
        public TodoItemService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            todoItemApiUrl = "https://localhost:7248";
        }

        public Task<T> CreateAsync<T>(TodoItemCreateDto todoItemCreateDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                HttpMethodType = ApiHttpMethod.MethodType.POST,
                Data = todoItemCreateDto,
                Url = todoItemApiUrl + "/api/todoitems"

            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                HttpMethodType = ApiHttpMethod.MethodType.DELETE,
                Url = todoItemApiUrl + "/api/todoitems/" + id

            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                HttpMethodType = ApiHttpMethod.MethodType.GET,
                Url = todoItemApiUrl + "/api/todoitems"

            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                HttpMethodType = ApiHttpMethod.MethodType.GET,
                Url = todoItemApiUrl + "/api/todoitems/" + id

            });
        }

        public Task<T> UpdateAsync<T>(int id, TodoItemUpdateDto todoItemUpdateDto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                HttpMethodType = ApiHttpMethod.MethodType.PUT,
                Data = todoItemUpdateDto,
                Url = todoItemApiUrl + "/api/todoitems/" + id
            });


        }

    }
}
