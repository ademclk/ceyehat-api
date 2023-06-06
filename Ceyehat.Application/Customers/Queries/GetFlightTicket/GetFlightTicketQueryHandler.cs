using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Application.Customers.Common;
namespace Ceyehat.Application.Customers.Queries.GetFlightTicket;
using MediatR;
using ErrorOr;

public class GetFlightTicketQueryHandler : IRequestHandler<GetFlightTicketQuery, ErrorOr<List<FlightTicketDtoResponse>>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IFlightRepository _flightRepository;
    private readonly IAirportRepository _airportRepository;
    private readonly ISeatRepository _seatRepository;

    public GetFlightTicketQueryHandler(ICustomerRepository customerRepository, IFlightRepository flightRepository, IAirportRepository airportRepository, ISeatRepository seatRepository)
    {
        _customerRepository = customerRepository;
        _flightRepository = flightRepository;
        _airportRepository = airportRepository;
        _seatRepository = seatRepository;
    }

    public async Task<ErrorOr<List<FlightTicketDtoResponse>>> Handle(GetFlightTicketQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByEmailAsync(request.Email!);
        
        var bookings = customer?.Bookings;
        
        var flightTicketDtos = new List<FlightTicketDtoResponse>();

        foreach (var booking in bookings!)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(booking.FlightId!);
            var departureAirport = await _airportRepository.GetAirportByIdAsync(flight?.DepartureAirportId!);
            var arrivalAirport = await _airportRepository.GetAirportByIdAsync(flight?.ArrivalAirportId!);
            var seat = await _seatRepository.GetSeatByIdAsync(booking.SeatId!);
            
            var flightTicketDto = new FlightTicketDtoResponse
            {
                Id = customer?.FlightTickets?.Where(f => f.BookingId == booking.Id).Select(f => f.Id.Value.ToString()).FirstOrDefault(),
                Name = customer?.Name,
                Surname = customer?.Surname,
                FlightNumber = flight?.FlightNumber,
                DepartureIata = departureAirport?.IataCode,
                DepartureName = departureAirport?.Name,
                ArrivalIata = arrivalAirport?.IataCode,
                ArrivalName = arrivalAirport?.Name,
                DepartureDate = flight?.ScheduledDeparture.ToString("dd/MM/yyyy"),
                ArrivalDate = flight?.ScheduledArrival.ToString("dd/MM/yyyy"),
                DepartureTime = flight?.ScheduledDeparture.ToString("HH:mm"),
                ArrivalTime = flight?.ScheduledArrival.ToString("HH:mm"),
                SeatNumber = seat?.SeatNumber,
                Price = booking.Price,
                Currency = booking.Currency.ToString(),
                Status = flight?.Status.ToString()
            };
            
            flightTicketDtos.Add(flightTicketDto);
        }
        
        return flightTicketDtos;
    }
}