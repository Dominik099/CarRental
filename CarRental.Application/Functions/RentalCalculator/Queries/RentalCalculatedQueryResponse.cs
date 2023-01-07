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
    public class RentalCalculatedQueryResponse 
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

        public RentalCalculatedQueryResponse() 
        { }

    }
}
