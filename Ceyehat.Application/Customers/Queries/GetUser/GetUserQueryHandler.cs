using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Application.Customers.Common;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Customers.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ErrorOr<UserDtoResponse?>>
{
    private readonly IUserRepository _userRepository;


    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserDtoResponse?>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email!);

        var res = new UserDtoResponse()
        {
            Id = user!.Id.Value.ToString(),
            CustomerId = user.CustomerId.Value.ToString(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };

        return res;
    }
}