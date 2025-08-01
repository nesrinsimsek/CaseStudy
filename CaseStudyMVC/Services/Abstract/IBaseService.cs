using CaseStudyMVC.Common;

namespace CaseStudyMVC.Services.Abstract
{
    public interface IBaseService
    {
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
