using HeathCheck.MVC.Models;

namespace HeathCheck.MVC.ApiServices.Interfaces
{
    public interface IApplicationApiService
    {
        Task<List<ApplicationModel>> GetApplicationsByUser(int userId);
        Task UpdateApplications(UpdateApplicationModel model);
        Task DeleteApplication(int applicationId);
        Task AddApplications(AddApplicationModel model);
    }
}
