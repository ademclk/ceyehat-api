using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AircraftAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Aircrafts.Commands.CreateAircraft;

public class CreateAircraftCommandHandler : IRequestHandler<CreateAircraftCommand, ErrorOr<Aircraft>>
{
    private readonly IAircraftRepository _aircraftRepository;

    public CreateAircraftCommandHandler(IAircraftRepository aircraftRepository)
    {
        _aircraftRepository = aircraftRepository;
    }

    public async Task<ErrorOr<Aircraft>> Handle(CreateAircraftCommand request, CancellationToken cancellationToken)
    {
        var aircraft = Aircraft.Create(
            request.RegistrationNumber,
            request.Icao24Code,
            request.Model,
            request.ManufacturerSerialNumber,
            request.FaaRegistration,
            request.CountryId,
            request.AirlineId);
        
        await _aircraftRepository.AddAircraftAsync(aircraft);
        
        return aircraft;
    }
}