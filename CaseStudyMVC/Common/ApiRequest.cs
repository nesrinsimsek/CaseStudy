using static CaseStudyMVC.Utility.ApiHttpMethod;

namespace CaseStudyMVC.Common
{
    public class ApiRequest
    {
        public MethodType HttpMethodType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
