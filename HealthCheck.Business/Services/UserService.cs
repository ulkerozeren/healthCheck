using AutoMapper;
using HealthCheck.Business.Abstraction;
using HealthCheck.Business.Dto.Request;
using HealthCheck.Business.Dto.Status;
using HealthCheck.Entity.Context;
using HealthCheck.Resources;
using Microsoft.EntityFrameworkCore;
using static HealthCheck.Business.Dto.Result.UserResult;

namespace HealthCheck.Business.Services
{
    public class UserService: IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;

        public UserService(AppDbContext dbContext, IValidationService validationService, IMapper mapper)
        {
            _dbContext = dbContext;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<SignInResult> SignIn(SignInRequest request) 
        { 
            var user=await _dbContext.User.FirstOrDefaultAsync(f=>f.UserName==request.UserName && f.Password==request.Password);

            if (user == null)
                return new SignInResult
                {
                    Status = UserResultStatus.NotFound,
                    Message = ServiceResources.RESOURCE_NOT_FOUND
                };

            return new SignInResult
            {
                Status = UserResultStatus.Successful,
                Data=new SignInDto { UserId=user.Id }
            };
        }


    }
}
