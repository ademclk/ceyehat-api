using Ceyehat.Application.Authentication.Commands.Register;
using Ceyehat.Application.Authentication.Common;
using MediatR;
using ErrorOr;
using FluentValidation;

namespace Ceyehat.Application.Common.Behaviours;

public class ValidateRegisterCommandBehaviour :
    IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidateRegisterCommandBehaviour(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(
        RegisterCommand request, 
        RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, 
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors
            .ConvertAll(validationFailure =>
                Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage));
        
        return errors;
    }
}
 