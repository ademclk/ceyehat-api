using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AircraftAggregate;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
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
        var countryId = CountryId.Create(Guid.Parse(request.CountryId!));
        var airlineId = AirlineId.Create(Guid.Parse(request.AirlineId!));

        var aircraft = Aircraft.Create(
            request.RegistrationNumber,
            request.Icao24Code,
            request.Model,
            request.ManufacturerSerialNumber,
            request.FaaRegistration,
            countryId,
            airlineId);

        await _aircraftRepository.AddAircraftAsync(aircraft);

        return aircraft;
    }
}