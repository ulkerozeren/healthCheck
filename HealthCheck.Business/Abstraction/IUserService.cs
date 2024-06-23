using HealthCheck.Business.Dto.Request;
using static HealthCheck.Business.Dto.Result.UserResult;

namespace HealthCheck.Business.Abstraction
{
    public interface IUserService
    {
        Task<SignInResult> SignIn(SignInRequest request);
    }
}
