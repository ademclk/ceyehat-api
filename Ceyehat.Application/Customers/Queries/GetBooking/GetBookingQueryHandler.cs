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
            var bookings = customer?.Bookings;
            var bookingDtos = new List<BookingDtoResponse>();

            foreach (var booking in bookings!)
            {
                var seat = await _seatRepository.GetSeatByIdAsync(booking.SeatId!);
                var flight = await _flightRepository.GetFlightByIdAsync(booking.FlightId!);

                var bookingDto = new BookingDtoResponse
                {
                    BookingId = booking.Id.Value.ToString(),
                    SeatId = booking.SeatId?.Value.ToString(),
                    SeatNumber = seat?.SeatNumber,
                    FlightId = booking.FlightId?.Value.ToString(),
                    FlightNumber = flight?.FlightNumber,
                    Currency = booking.Currency.ToString(),
                    Price = booking.Price,
                    PassengerType = TranslatePassengerType(booking.PassengerType), // Translate passenger type
                };

                bookingDtos.Add(bookingDto);
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
