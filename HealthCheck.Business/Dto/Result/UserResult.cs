using HealthCheck.Business.Dto.Status;
using HealthCheck.Core.Response;

namespace HealthCheck.Business.Dto.Result
{
    public class UserResult
    {
        public class BaseApplicationResult : BaseServiceResult<UserResultStatus> { }

        public class SignInResult : BaseApplicationResult
        {
            public SignInDto Data { get; set; }
        }

        public class SignInDto
        {
            public int UserId { get; set; }
        }
    }
}
