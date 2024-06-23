using FluentValidation;
using HealthCheck.Business.Dto.Request;
using HealthCheck.Resources;

namespace HealthCheck.Business.Validators
{
    internal class AddApplicationValidator:AbstractValidator<AddApplicationRequest>
    {
        public AddApplicationValidator()
        {
            RuleFor(p => p.UserId).GreaterThan(0).WithMessage(p => string.Format(ServiceResources.INVALID_INPUT_ERROR, nameof(p.UserId)));
            RuleFor(p => p.NotificationTypeId).GreaterThan(0).WithMessage(p => string.Format(ServiceResources.INVALID_INPUT_ERROR, nameof(p.NotificationTypeId)));
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage(p => string.Format(ServiceResources.PROPERTY_REQUIRED, nameof(p.Name)));
            RuleFor(p => p.MailBody).NotNull().NotEmpty().WithMessage(p => string.Format(ServiceResources.PROPERTY_REQUIRED, nameof(p.MailBody)));
            RuleFor(p => p.MailSubject).NotNull().NotEmpty().WithMessage(p => string.Format(ServiceResources.PROPERTY_REQUIRED, nameof(p.MailSubject)));
            RuleFor(p => p.Mail).NotNull().NotEmpty().WithMessage(p => string.Format(ServiceResources.PROPERTY_REQUIRED, nameof(p.Mail)));
            RuleFor(p => p.Url).NotNull().NotEmpty().WithMessage(p => string.Format(ServiceResources.PROPERTY_REQUIRED, nameof(p.Url)));
        }
    }

    internal class DeleteApplicationValidator : AbstractValidator<DeleteApplicationRequest>
    {
        public DeleteApplicationValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage(p => string.Format(ServiceResources.INVALID_INPUT_ERROR, nameof(p.Id)));           
        }
    }

    internal class UpdateApplicationValidator : AbstractValidator<UpdateApplicationRequest>
    {
        public UpdateApplicationValidator()
        {
            RuleFor(p => p.AppllicationId).GreaterThan(0).WithMessage(p => string.Format(ServiceResources.INVALID_INPUT_ERROR, nameof(p.AppllicationId)));
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage(p => string.Format(ServiceResources.PROPERTY_REQUIRED, nameof(p.Name)));
            RuleFor(p => p.Url).NotNull().NotEmpty().WithMessage(p => string.Format(ServiceResources.PROPERTY_REQUIRED, nameof(p.Url)));
        }
    }

    internal class GetApplicationsByUserValidator : AbstractValidator<GetApplicationsByUserRequest>
    {
        public GetApplicationsByUserValidator()
        {
            RuleFor(p => p.UserId).GreaterThan(0).WithMessage(p => string.Format(ServiceResources.INVALID_INPUT_ERROR, nameof(p.UserId)));
        }
    }
}
