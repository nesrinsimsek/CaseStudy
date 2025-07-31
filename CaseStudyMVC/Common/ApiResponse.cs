using System.Net;

namespace CaseStudyMVC.Common
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}
