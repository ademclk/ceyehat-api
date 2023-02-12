using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AirlineAggregate;
using ErrorOr;
using MediatR;
using AirlineAddress = Ceyehat.Domain.AirlineAggregate.Entities.AirlineAddress;

namespace Ceyehat.Application.Airlines.Commands.CreateAirline;

public class CreateAirlineCommandHandler : IRequestHandler<CreateAirlineCommand, ErrorOr<Airline>>
{
    private readonly IAirlineRepository _airlineRepository;

    public CreateAirlineCommandHandler(IAirlineRepository airlineRepository)
    {
        _airlineRepository = airlineRepository;
    }

    public async Task<ErrorOr<Airline>> Handle(CreateAirlineCommand request, CancellationToken cancellationToken)
    {
        var airline = Airline.Create(
            request.Name,
            request.IataCode,
            request.IcaoCode,
            request.Callsign,
            request.Country,
            request.Website,
            AirlineAddress.Create(request.Address.City));

        await _airlineRepository.AddAirlineAsync(airline);
        
        return airline;
    }
}