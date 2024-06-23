using HealthCheck.Core.Attribute;
using HealthCheck.Core.Response.Enums;
using HealthCheck.Resources;


namespace HealthCheck.Business.Dto.Status
{
    public enum ApplicationResultStatus
    {

        [CustomHttpStatus(Code = HttpCustomResponseCodes.SUCCESS, Resources = typeof(ServiceResources), Status = HttpStatus.SUCCESS, StatusCode = HttpStatusCodes.Ok)]
        Successful,

        [CustomHttpStatus(Code = HttpCustomResponseCodes.CREATED, Resources = typeof(ServiceResources), Status = HttpStatus.CREATED, StatusCode = HttpStatusCodes.Created)]
        Created,

        [CustomHttpStatus(Code = HttpCustomResponseCodes.INPUT_ERROR, Resources = typeof(ServiceResources), Status = HttpStatus.INVALID_INPUT, StatusCode = HttpStatusCodes.InvalidInput)]
        InvalidInput,

        [CustomHttpStatus(Code = HttpCustomResponseCodes.INTERNAL_SERVER_ERROR, Resources = typeof(ServiceResources), Status = HttpStatus.FAILED, StatusCode = HttpStatusCodes.InternalError)]
        InternalServerError,

        [CustomHttpStatus(Code = HttpCustomResponseCodes.RESOURCE_NOT_FOUND, Resources = typeof(ServiceResources), Status = HttpStatus.NOT_FOUND, StatusCode = HttpStatusCodes.ResourceNotFound)]
        NotFound,

        [CustomHttpStatus(Code = HttpCustomResponseCodes.RESOURCE_FOUND, Resources = typeof(ServiceResources), Status = HttpStatus.FOUND, StatusCode = HttpStatusCodes.ResourceExist)]
        AlreadyExist,

        [CustomHttpStatus(Code = HttpCustomResponseCodes.PRECONDITON_FAILED, Resources = typeof(ServiceResources), Status = HttpStatus.PRECONDITON_FAILED, StatusCode = HttpStatusCodes.PreconditionFailed)]
        PreconditionFailed
    }
}
