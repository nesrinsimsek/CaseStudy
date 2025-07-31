using static CaseStudyMVC.Utility.HttpMethod;

namespace CaseStudyMVC.Common
{
    public class ApiRequest
    {
        public MethodType MethodType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
