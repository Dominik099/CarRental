using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Responses;
using FluentValidation;
using FluentValidation.Results;

namespace CarRental.Application.Functions.RentalCalculator.Queries
{
    public class RentalCalculatedQueryResponse : BaseResponse
    {
        public decimal FuelPrice { get; set; }
        public decimal BaseCost { get; set;}
        public decimal PeriodCost { get; set; }
        public decimal CategoryCost { get; set; }
        public decimal YoungDriverCost { get; set; }
        public decimal FewPiecesCost { get; set; }
        public decimal FuelCost { get; set; }
        public decimal TotalCostNetto { get; set; }
        public decimal TotalCostBrutto { get; set; }

        public RentalCalculatedQueryResponse() : base()
        { }

        public RentalCalculatedQueryResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public RentalCalculatedQueryResponse(string message)
        : base(message)
        { }

        public RentalCalculatedQueryResponse(string message, bool success)
            : base(message, success)
        { }

        public RentalCalculatedQueryResponse(decimal fuelPrice, decimal baseCost, decimal pieriodCost, decimal categoryCost,
            decimal youngDriverCost, decimal fewPiecesCost, decimal fuelCost, decimal totalCostNetto, decimal totalCostBrutto)
        {
            FuelPrice = fuelPrice;
            BaseCost = baseCost;
            PeriodCost = pieriodCost;
            CategoryCost = categoryCost;
            YoungDriverCost= youngDriverCost;
            FewPiecesCost = fewPiecesCost;
            FuelCost = fuelCost;
            TotalCostNetto = totalCostNetto;
            TotalCostBrutto= totalCostBrutto;
        }
    }
}
