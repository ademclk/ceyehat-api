using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Application.Customers.Common;
using MediatR;
using ErrorOr;
using System.Collections.Generic;
using Ceyehat.Domain.Enums;

namespace Ceyehat.Application.Customers.Queries.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, ErrorOr<List<BookingDtoResponse>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IFlightRepository _flightRepository;

        // Dictionary to map enum values to their Turkish translations
        private readonly Dictionary<PassengerType, string> passengerTypeTranslations = new Dictionary<PassengerType, string>
        {
            { PassengerType.Adult, "Yetişkin" },
            { PassengerType.Child, "Çocuk" },
            { PassengerType.Infant, "Bebek" },
            { PassengerType.Disabled, "Engelli" },
            { PassengerType.Student, "Öğrenci" }
        };

        public GetBookingQueryHandler(ICustomerRepository customerRepository, ISeatRepository seatRepository, IFlightRepository flightRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _seatRepository = seatRepository;
            _flightRepository = flightRepository;
        }

        public async Task<ErrorOr<List<BookingDtoResponse>>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByEmailAsync(request.Email!);
            if (customer?.Bookings is null)
            {
                return new List<BookingDtoResponse>();
            }

            var bookings = customer.Bookings;
            var bookingDtos = new List<BookingDtoResponse>();

            foreach (var booking in bookings!)
            {
                try
                {
                    var seat = await _seatRepository.GetSeatByIdAsync(booking.SeatId!);
                    var flight = await _flightRepository.GetFlightByIdAsync(booking.FlightId!);

                    if (seat is null || flight is null)
                    {
                        continue;
                    }

                    var bookingDto = new BookingDtoResponse
                    {
                        BookingId = booking.Id.Value.ToString(),
                        SeatId = booking.SeatId?.Value.ToString(),
                        SeatNumber = seat?.SeatNumber,
                        FlightId = booking.FlightId?.Value.ToString(),
                        FlightNumber = flight?.FlightNumber,
                        Currency = booking.Currency.ToString(),
                        Price = booking.Price,
                        PassengerType = TranslatePassengerType(booking.PassengerType),
                    };

                    bookingDtos.Add(bookingDto);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return bookingDtos;
        }

        private string TranslatePassengerType(PassengerType passengerType)
        {
            // Return the Turkish translation from the dictionary
            return passengerTypeTranslations.TryGetValue(passengerType, out var translation) ? translation : string.Empty;
        }
    }
}
