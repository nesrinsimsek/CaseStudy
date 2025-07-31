using System.Net;

namespace CaseApi
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}
