using AutoMapper;
using HealthCheck.API.RequestModel;
using HealthCheck.Business.Abstraction;
using HealthCheck.Business.Dto.Request;
using HealthCheck.Core.Response;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("user/sign-in")]
        public async Task<IActionResult> SignIn(SignInRequestModel requestModel)
        {
            var serviceRequest = _mapper.Map<SignInRequest>(requestModel); 
            var result = await _userService.SignIn(serviceRequest);

            return BaseResponseFactory.CreateResponse(result, result.Data);
        }
    }
}
