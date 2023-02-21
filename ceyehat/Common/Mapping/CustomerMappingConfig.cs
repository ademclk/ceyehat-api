using Ceyehat.Contracts.Customers;
using Ceyehat.Domain.CustomerAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class CustomerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCustomerRequest, Customer>();

        config.NewConfig<Customer, CustomerResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value);
    }
}