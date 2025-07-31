using System.Net;

namespace CaseApi.Common
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}
