namespace CaseStudyMVC.Services.Abstract
{
    public interface IUserService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
    }
}
