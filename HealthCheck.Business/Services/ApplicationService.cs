using AutoMapper;
using HealthCheck.Business.Abstraction;
using HealthCheck.Business.Dto;
using HealthCheck.Business.Dto.Request;
using HealthCheck.Business.Dto.Result;
using HealthCheck.Business.Dto.Status;
using HealthCheck.Business.Validators;
using HealthCheck.Entity.Context;
using HealthCheck.Entity.Models;
using HealthCheck.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthCheck.Business.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;

        public ApplicationService(AppDbContext dbContext, IValidationService validationService, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<AddApplicationResult> AddApplication(AddApplicationRequest request)
        {
            var validationResult = _validationService.Validate(typeof(AddApplicationValidator), request);

            if (!validationResult.IsValid)
                return new AddApplicationResult
                {
                    Status = ApplicationResultStatus.InvalidInput,
                    Message = ServiceResources.INVALID_INPUT_ERROR,
                    ValidationMessages = validationResult.ErrorMessages
                };

            var application = new Application
            {
                Mail = request.Mail,
                MailBody = request.MailBody,
                MailSubject = request.MailSubject,
                Name = request.Name,
                NotificationTypeId = request.NotificationTypeId,
                Url = request.Url,
                UserId = request.UserId
            };

            await _dbContext.Application.AddAsync(application);
            await _dbContext.SaveChangesAsync();

            return new AddApplicationResult
            {
                Status = ApplicationResultStatus.Successful,
                Message = ServiceResources.SUCCESSFUL
            };
        }

        public async Task<DeleteApplicationResult> DeleteApplication(DeleteApplicationRequest request)
        {
            try
            {
                var validationResult = _validationService.Validate(typeof(DeleteApplicationValidator), request);

                if (!validationResult.IsValid)
                    return new DeleteApplicationResult
                    {
                        Status = ApplicationResultStatus.InvalidInput,
                        Message = ServiceResources.INVALID_INPUT_ERROR,
                        ValidationMessages = validationResult.ErrorMessages
                    };

                var application = await _dbContext.Application.FindAsync(request.Id);
                if (application == null)
                    return new DeleteApplicationResult
                    {
                        Status = ApplicationResultStatus.NotFound,
                        Message = ServiceResources.RESOURCE_NOT_FOUND
                    };

                application.IsDeleted = true;
                _dbContext.Application.Update(application);
                await _dbContext.SaveChangesAsync();

                return new DeleteApplicationResult
                {
                    Status = ApplicationResultStatus.Successful,
                    Message = ServiceResources.SUCCESSFUL
                };
            }
            catch (Exception exc)
            {
                return new DeleteApplicationResult
                {
                    Status = ApplicationResultStatus.InternalServerError,
                    Message = ServiceResources.FAILED
                };
            }
        }

        public async Task<UpdateApplicationResult> UpdateApplication(UpdateApplicationRequest request)
        {
            try
            {
                var validationResult = _validationService.Validate(typeof(UpdateApplicationValidator), request);

                if (!validationResult.IsValid)
                    return new UpdateApplicationResult
                    {
                        Status = ApplicationResultStatus.InvalidInput,
                        Message = ServiceResources.INVALID_INPUT_ERROR,
                        ValidationMessages = validationResult.ErrorMessages
                    };

                var application = await _dbContext.Application.FindAsync(request.AppllicationId);

                if (application == null)
                    return new UpdateApplicationResult
                    {
                        Status = ApplicationResultStatus.NotFound,
                        Message = ServiceResources.RESOURCE_NOT_FOUND
                    };

                application.Url = request.Url;
                application.Name = request.Name;

                _dbContext.Application.Update(application);
                await _dbContext.SaveChangesAsync();

                return new UpdateApplicationResult
                {
                    Status = ApplicationResultStatus.Successful,
                    Message = ServiceResources.SUCCESSFUL
                };

            }
            catch (Exception exc)
            {
                return new UpdateApplicationResult
                {
                    Status = ApplicationResultStatus.InternalServerError,
                    Message = ServiceResources.FAILED
                };
            }
        }

        public async Task<GetApplicationResult> GetApplicationsByUser(GetApplicationsByUserRequest request)
        {
            try
            {
                var validationResult = _validationService.Validate(typeof(GetApplicationsByUserValidator), request);

                if (!validationResult.IsValid)
                    return new GetApplicationResult
                    {
                        Status = ApplicationResultStatus.InvalidInput,
                        Message = ServiceResources.INVALID_INPUT_ERROR,
                        ValidationMessages = validationResult.ErrorMessages
                    };

                var applications = await _dbContext.Application.Where(w => w.UserId == request.UserId && !w.IsDeleted).ToListAsync();

                if (!applications.Any())
                    return new GetApplicationResult
                    {
                        Status = ApplicationResultStatus.NotFound,
                        Message = ServiceResources.RESOURCE_NOT_FOUND
                    };

                return new GetApplicationResult
                {
                    Status = ApplicationResultStatus.Successful,
                    Message = ServiceResources.SUCCESSFUL,
                    Applications=_mapper.Map<List<ApplicationDto>>(applications),
                };

            }
            catch (Exception exc)
            {
                return new GetApplicationResult
                {
                    Status = ApplicationResultStatus.InternalServerError,
                    Message = ServiceResources.FAILED
                };
            }
        }
    }
}
