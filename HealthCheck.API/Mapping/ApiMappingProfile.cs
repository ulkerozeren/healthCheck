using AutoMapper;
using HealthCheck.API.RequestModel;
using HealthCheck.Business.Dto;
using HealthCheck.Business.Dto.Request;
using HealthCheck.Entity.Models;

namespace HealthCheck.API.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
           
            #region Request
            CreateMap<AddApplicationRequestModel, AddApplicationRequest>().ReverseMap();
            CreateMap<UpdateApplicationRequestModel, UpdateApplicationRequest>().ReverseMap();
            CreateMap<SignInRequestModel, SignInRequest>().ReverseMap();
            #endregion

            #region DTO
            CreateMap<Application, ApplicationDto>().ReverseMap();
            #endregion

        }
    }
}
