using CaseStudyMVC.Common;
using CaseStudyMVC.Services.Abstract;
using CaseStudyMVC.Utility;
using Newtonsoft.Json;
using System.Text;

namespace CaseStudyMVC.Services.Concrete
{
    public class BaseService : IBaseService
    {
        public IHttpClientFactory _httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            var client = _httpClient.CreateClient("CaseAPI");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json");
            }
            switch (apiRequest.HttpMethodType)
            {
                case ApiHttpMethod.MethodType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiHttpMethod.MethodType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiHttpMethod.MethodType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;

            }

            var apiResponse = await client.SendAsync(message);

            var apiContentStr = await apiResponse.Content.ReadAsStringAsync();

            var apiResponseExceptionReturnObj = JsonConvert.DeserializeObject<T>(apiContentStr);

            return apiResponseExceptionReturnObj;
        }
    }
}
