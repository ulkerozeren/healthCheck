using HealthCheck.Business.Dto.Status;
using HealthCheck.Core.Response;

namespace HealthCheck.Business.Dto.Result
{
    public class BaseApplicationResult : BaseServiceResult<ApplicationResultStatus> { }
    public class AddApplicationResult : BaseApplicationResult
    {

    }

    public class DeleteApplicationResult : BaseApplicationResult
    {

    }

    public class UpdateApplicationResult : BaseApplicationResult
    {

    }

    public class GetApplicationResult : BaseApplicationResult
    {
        public List<ApplicationDto> Applications { get; set; }
    }
    
   
}
