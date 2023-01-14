using Ceyehat.Application.Authentication.Common;
using Ceyehat.Contracts.Authentication;
using Mapster;

namespace ceyehat.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}