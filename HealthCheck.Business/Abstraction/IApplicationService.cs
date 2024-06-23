using HealthCheck.Business.Dto.Request;
using HealthCheck.Business.Dto.Result;

namespace HealthCheck.Business.Abstraction
{
    public interface IApplicationService
    {
        Task<AddApplicationResult> AddApplication(AddApplicationRequest request);
        Task<DeleteApplicationResult> DeleteApplication(DeleteApplicationRequest request);
        Task<UpdateApplicationResult> UpdateApplication(UpdateApplicationRequest request);
        Task<GetApplicationResult> GetApplicationsByUser(GetApplicationsByUserRequest request);
    }
}
