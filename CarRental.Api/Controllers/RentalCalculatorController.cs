using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById;
using CarRental.Application.Functions.Cars.Queries.GetCarById;
using CarRental.Application.RentalCalculator;
using CarRental.Application.Contracts.Persistence;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalCalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRentalCalculator _rentalCalculator;

        public RentalCalculatorController(IMediator mediator, IRentalCalculator rentalCalculator)
        {
            _mediator = mediator;
            _rentalCalculator = rentalCalculator;   
        }

        [HttpGet(Name = "CarRentalCalculator")]
        public async Task<ActionResult> CalculatePrice([FromQuery]int carId, [FromQuery]int kilometers, [FromQuery]DateTime driverLicenceDate,
            [FromQuery]DateTime rentalDate, [FromQuery]DateTime returnDate)
        {
            var selectedCar = await _mediator.Send(new GetCarByIdQuery() { Id = carId });
            var userInput = new UserInput(selectedCar, kilometers, driverLicenceDate, rentalDate, returnDate);

            var baseCost = _rentalCalculator.CalculateForPeriod(userInput.RentalDate, userInput.ReturnDate);
            var categoryCost = Math.Round(_rentalCalculator.CalculateForCategory(userInput.SelectedCar, baseCost), 2);
            var youngDriverCost = categoryCost;

            if (DateTime.UtcNow.Year - userInput.DriverLicenceDate.Year < 5)
            {
                youngDriverCost = Math.Round(_rentalCalculator.CalculateForDriverLicenceDate(userInput.DriverLicenceDate, categoryCost), 2);
            }
            var fewPiecesCost = youngDriverCost;

            if (userInput.SelectedCar.NumberOfCars < 3)
            {
                fewPiecesCost = Math.Round(_rentalCalculator.CalculateForFewPieces(userInput.SelectedCar, fewPiecesCost), 2);
            }

            var fuelCost = Math.Round(_rentalCalculator.CalculateForFuelCost(userInput.SelectedCar, kilometers), 2);

            var totalCostNetto = Math.Round(fewPiecesCost + fuelCost, 2);
            var totalCostBrutto = Math.Round(_rentalCalculator.CalculateNettoToBrutto(totalCostNetto), 2);

            return Ok($"Wybrany samochod: {selectedCar.Mark} {selectedCar.Model} \n" +
                $"Bazowy koszt za wypozyczenie samochodu na {returnDate.Day - rentalDate.Day} dni: {baseCost} zl\n" +
                $"Dodatkowy koszt ze wzgledu na kategorie cenowa {selectedCar.PriceCategory.Category}: {categoryCost - baseCost} zl\n" +
                $"Dodatkowy koszt ze wzgledu na posiadanie prawa jazdy ponizej 3 lat : {youngDriverCost - categoryCost} zl\n" +
                $"Dodatkowy koszt ze względu na mala ilosc sztuk danego egzemplarza: {fewPiecesCost - youngDriverCost} zl\n" +
                $"Koszt paliwa na {kilometers} kilometrow, przy spalaniu {selectedCar.AVGFuelConsumption} l : {fuelCost} zl\n" +
                $"Cena koncowa netto: {totalCostNetto} zl\n" +
                $"Cena koncowa brutto: {totalCostBrutto} zl");
        }

    }
}
