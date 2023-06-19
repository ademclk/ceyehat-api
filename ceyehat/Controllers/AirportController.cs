using Ceyehat;
using Ceyehat.Application.Airports.Commands.CreateAirport;
using Ceyehat.Application.Airports.Queries.GetAirports;
using Ceyehat.Application.Common.DTOs;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Contracts.Airports;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AirportController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        private readonly AirportRecommenderMLModel _mlModel;
        private readonly IAirportRepository _airportRepository;

        public AirportController(IMapper mapper, ISender mediator, AirportRecommenderMLModel mlModel, IAirportRepository airportRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _mlModel = mlModel;
            _airportRepository = airportRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAirport(CreateAirportRequest request)
        {
            var command = _mapper.Map<CreateAirportCommand>(request);
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                airport => Ok(_mapper.Map<AirportResponse>(airport)),
                error => Problem(error));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAirports()
        {
            var result = await _mediator.Send(new GetAirportsQuery());
            return result.Match<IActionResult>(
                airports => Ok(_mapper.Map<List<AirportResponse>>(airports)),
                error => Problem(error));
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchAirports(string? searchTerm)
        {
            var airportDtos = await _airportRepository.SearchAirportsAsync(searchTerm);
            return Ok(airportDtos);
        }

        [HttpGet]
        [Route("recommendations")]
        public async Task<IActionResult> GetRecommendedAirports(string userId)
        {
            var sampleData = new AirportRecommenderMLModel.ModelInput()
            {
                UserId = userId,
            };

            var modelOutput = AirportRecommenderMLModel.Predict(sampleData);
            var airportId = modelOutput.PredictedLabel;

            var airport = await _airportRepository.GetAirportByIdStringAsync(airportId);

            var airportDto = new AirportDto
            {
                Name = airport?.Name,
                IataCode = airport?.IataCode,
                CityName = airport?.CityName,
                CountryName = airport?.CountryName,
                Longitude = airport?.Longitude ?? default,
                Latitude = airport?.Latitude ?? default,
            };

            return Ok(new List<AirportDto> { airportDto });
        }
    }
}
