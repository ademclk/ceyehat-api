using Ceyehat.Application.Customers.Commands.AddPassenger;
using Ceyehat.Application.Customers.Commands.CreateTicket;
using Ceyehat.Contracts.Customers;
using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.CustomerAggregate.Entities;
using Mapster;

namespace ceyehat.Common.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCustomerRequest, Customer>();

        config.NewConfig<Customer, CustomerResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.Bookings, src => src.Bookings)
            .Map(dest => dest.FlightTickets, src => src.FlightTickets)
            .Map(dest => dest.BoardingPasses, src => src.BoardingPasses);

        config.NewConfig<AddPassengerRequest, AddPassengerCommand>()
            .Map(dest => dest.AddBookingCommands, src => src.AddBookingRequests);

        config.NewConfig<Booking, BookingResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.FlightId, src => src.FlightId!.Value)
            .Map(dest => dest.SeatId, src => src.SeatId!.Value);
        
        config.NewConfig<FlightTicket, FlightTicketResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.BookingId, src => src.BookingId!.Value);

        config.NewConfig<BoardingPass, BoardingPassResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        
        config.NewConfig<CreateTicketRequest, CreateTicketCommand>();
    }
}