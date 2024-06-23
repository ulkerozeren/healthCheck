using AutoMapper;
using HealthCheck.API.RequestModel;
using HealthCheck.Business.Abstraction;
using HealthCheck.Business.Dto.Request;
using HealthCheck.Core.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HealthCheck.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("applications/{userId}")]
        public async Task<IActionResult> GetApplicationsByUser(int userId)
        {
            var result = await _applicationService.GetApplicationsByUser(new GetApplicationsByUserRequest { UserId=userId });

            return BaseResponseFactory.CreateResponse(result, result.Applications);
        }

        [HttpPost]
        [Route("applications/add-application")]
        public async Task<IActionResult> AddApplication(
           [FromForm] AddApplicationRequestModel requestModel)
        {
            var serviceRequest = _mapper.Map<AddApplicationRequest>(requestModel);
            var result = await _applicationService.AddApplication(serviceRequest);

            return BaseResponseFactory.CreateResponse(result);
        }

        [HttpDelete]
        [Route("applications/{applicationId}")]
        public async Task<IActionResult> DeleteApplication(int applicationId)
        {          
            var result = await _applicationService.DeleteApplication(new DeleteApplicationRequest { Id=applicationId});

            return BaseResponseFactory.CreateResponse(result);
        }

        [HttpPut]
        [Route("applications/{applicationId}")]
        public async Task<IActionResult> UpdateApplication([FromForm] UpdateApplicationRequestModel requestModel, int applicationId)
        {
            var serviceRequest = _mapper.Map<UpdateApplicationRequest>(requestModel);
            serviceRequest.AppllicationId = applicationId;

            var result = await _applicationService.UpdateApplication(serviceRequest);

            return BaseResponseFactory.CreateResponse(result);
        }
    }
}
