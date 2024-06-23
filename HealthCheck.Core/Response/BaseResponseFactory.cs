using HealthCheck.Core.Attribute;
using HealthCheck.Core.Response.Enums;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using HealthCheck.Core.Extensions;

namespace HealthCheck.Core.Response
{
    public static class BaseResponseFactory
    {
        public static ObjectResult CreateResponse<TResult>(TResult result, object data = null)
        {
            var statusValue = result.GetType().GetProperty("Status")?.GetValue(result)?.ToString();

            var enumType = result.GetType().GetProperty("Status")?.PropertyType;

            var methodInfo = enumType?.GetMembers(BindingFlags.Public | BindingFlags.Static);

            if (methodInfo == null)
            {
                return new ObjectResult(new BaseApiResponse
                {
                    Status = HttpStatus.INTERNAL_SERVER_ERROR,
                    Code = HttpCustomResponseCodes.INTERNAL_SERVER_ERROR,
                    Message = "Matched status attribute cannot be found"
                })
                { StatusCode = HttpStatusCodes.InternalError };
            }

            var st = methodInfo.FirstOrDefault(w => w.Name == statusValue);

            if (st != null)
            {
                var attr = st.GetCustomAttribute<CustomHttpStatusAttribute>();
                if (attr != null)
                {
                    var message = result.GetType().GetProperty("Message")?.GetValue(result)?.ToString();

                    if (result.GetType().GetProperty("ValidationMessages")?.GetValue(result) is IList<string> validationMessages)
                    {
                        object response = result.GetType().GetProperty("TotalNumberOfPages") == null
                            ?
                            new BaseApiResponse
                            {
                                Status = attr.Status,
                                Code = attr.Code,
                                Message = message,
                                Data = data,
                                ValidationMessages = validationMessages.ToList()
                            }
                            :
                            new BasePaginationApiResponse
                            {
                                Status = attr.Status,
                                Code = attr.Code,
                                Message = message,
                                Data = data,
                                ValidationMessages = validationMessages.ToList(),
                                TotalNumberOfPages = result.GetType().GetProperty("TotalNumberOfPages")?.GetValue(result)?.ToIntNullable(),
                                TotalNumberOfRecords = result.GetType().GetProperty("TotalNumberOfRecords")?.GetValue(result)?.ToIntNullable(),

                            };

                        return new ObjectResult(response)
                        { StatusCode = attr.StatusCode };
                    }

                }
                else
                {
                    return new ObjectResult(new BaseApiResponse
                    {
                        Status = HttpStatus.INTERNAL_SERVER_ERROR,
                        Code = HttpCustomResponseCodes.INTERNAL_SERVER_ERROR,
                        Message = "Matched status attribute cannot be found"
                    })
                    { StatusCode = HttpStatusCodes.InternalError };
                }
            }
            else
            {
                return new ObjectResult(new BaseApiResponse
                {
                    Status = HttpStatus.INTERNAL_SERVER_ERROR,
                    Code = HttpCustomResponseCodes.INTERNAL_SERVER_ERROR,
                    Message = "An error occured"
                })
                { StatusCode = HttpStatusCodes.InternalError };
            }

            return new ObjectResult(new BaseApiResponse
            {
                Status = HttpStatus.INTERNAL_SERVER_ERROR,
                Code = HttpCustomResponseCodes.INTERNAL_SERVER_ERROR,
                Message = "Matched status attribute cannot be found"
            })
            { StatusCode = HttpStatusCodes.InternalError };
        }
    }
}
