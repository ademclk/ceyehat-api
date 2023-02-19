using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.PriceAggregate.ValueObjects;

namespace Ceyehat.Domain.PriceAggregate.Entities;

public sealed class FlightPricing : Entity<FlightPricingId>
{
    public decimal BaseCost { get; private set; }
    public decimal MarkupPercentage { get; private set; }
    public decimal DemandMultiplier { get; private set; }
    public decimal CompetitionMultiplier { get; private set; }
    public decimal SeasonalMultiplier { get; private set; }
    public decimal LengthMultiplier { get; private set; }
    public decimal ClassMultiplier { get; private set; }
    public decimal TotalCost { get; private set; }
    
    private FlightPricing(
        FlightPricingId id, 
        decimal baseCost, 
        decimal markupPercentage, 
        decimal demandMultiplier, 
        decimal competitionMultiplier, 
        decimal seasonalMultiplier, 
        decimal lengthMultiplier, 
        decimal classMultiplier, 
        decimal totalCost)
    {
        Id = id;
        BaseCost = baseCost;
        MarkupPercentage = markupPercentage;
        DemandMultiplier = demandMultiplier;
        CompetitionMultiplier = competitionMultiplier;
        SeasonalMultiplier = seasonalMultiplier;
        LengthMultiplier = lengthMultiplier;
        ClassMultiplier = classMultiplier;
        TotalCost = totalCost;
    }
    
    public static FlightPricing Create(
        decimal baseCost, 
        decimal markupPercentage, 
        decimal demandMultiplier, 
        decimal competitionMultiplier, 
        decimal seasonalMultiplier, 
        decimal lengthMultiplier, 
        decimal classMultiplier)
    {
        var totalCost = CalculateTotalCost();

        decimal CalculateTotalCost()
        {
            var total = baseCost * (1 + markupPercentage);
            total *= demandMultiplier;
            total *= competitionMultiplier;
            total *= seasonalMultiplier;
            total *= lengthMultiplier;
            total *= classMultiplier;
            return total;
        }

        return new(
            FlightPricingId.CreateUnique(), 
            baseCost, 
            markupPercentage, 
            demandMultiplier, 
            competitionMultiplier, 
            seasonalMultiplier, 
            lengthMultiplier, 
            classMultiplier, 
            totalCost);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected FlightPricing()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable. 
    
}