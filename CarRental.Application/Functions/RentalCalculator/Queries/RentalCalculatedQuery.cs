using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using System.ComponentModel.DataAnnotations;
using MediatR;
using CarRental.Application.RentalCalculator;
using CarRental.Application.RentalCalculator.Exceptions;
using CarRental.Application.Functions.RentalCalculator.Queries;

namespace CarRental.Application.RentalCalculator
{
    public class RentalCalculatedQuery : IRequest<CalculatedViewModel>
    {
        public int CarId { get; set; }
        public int EstimatedKilometers { get; set; }
        public DateTime DriverLicenceDate { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        //public RentalCalculatedQuery(int carId, int estimadedKilometers, DateTime driverLicenceDate, DateTime rentalDate, DateTime returnDate)
        //{
        //    //GuardBeforeInvalidCar(selectedCar);
        //    CarId = carId;
        //    //GuardBeforeTooLongKilometers(estimadedKilometers);
        //    EstimatedKilometers = estimadedKilometers;
        //    //GuardBeforeTooYoungDriver(driverLicenceDate);
        //    DriverLicenceDate = driverLicenceDate;
        //    //GuardBeforeInvalidRentalDate(rentalDate);
        //    RentalDate = rentalDate;
        //    //GuardBeforeInvalidReturnDate(returnDate);
        //    ReturnDate = returnDate;
        //}

        //public RentalCalculatedQuery()
        //{
        //}

        //private void GuardBeforeInvalidCar(CarViewModel selectedCar)
        //{
        //    if (selectedCar == null) throw new SelectedCarInvalidException();
        //}

        //private void GuardBeforeTooYoungDriver(DateTime driverLicenceDate)
        //{
        //    if (DateTime.UtcNow.Year - driverLicenceDate.Year < 3 && SelectedCar.PriceCategory.Category == "Premium") throw new TooYoungDriverException();
        //    if (driverLicenceDate == DateTime.MinValue) throw new DriverLicenceDataIsInvalidException();
        //}

        //private void GuardBeforeTooLongKilometers(int kilometers)
        //{
        //    if (kilometers > 10000 || kilometers == null) throw new TooLongKilometersException();
        //}

        //private void GuardBeforeInvalidRentalDate(DateTime rentalDate)
        //{
        //    if (DateTime.UtcNow.Day > rentalDate.Day || rentalDate == DateTime.MinValue) throw new RentalDateInvalidException();
        //}

        //private void GuardBeforeInvalidReturnDate(DateTime returnDate)
        //{
        //    if (returnDate.Day < RentalDate.Day || returnDate == DateTime.MinValue) throw new ReturnDateInvalidException();
        //}


    }


}
