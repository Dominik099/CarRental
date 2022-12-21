using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using System.ComponentModel.DataAnnotations;
using CarRental.Persistence.EF.Repositories.Exceptions;

namespace CarRental.Application.RentalCalculator
{
    public class UserInput
    {
        public CarViewModel SelectedCar { get; set; }
        public int EstimatedKilometers { get; set; }
        public DateTime DriverLicenceDate { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public UserInput(CarViewModel selectedCar, int estimadedKilometers, DateTime driverLicence, DateTime rentalDate, DateTime returnDate)
        {
            GuardBeforeInvalidCar(selectedCar);
            SelectedCar = selectedCar;
            GuardBeforeTooLongKilometers(estimadedKilometers);
            EstimatedKilometers = estimadedKilometers;
            GuardBeforeTooYoungDriver(driverLicence);
            DriverLicenceDate = driverLicence;
            GuardBeforeInvalidRentalDate(rentalDate);
            RentalDate = rentalDate;
            GuardBeforeInvalidReturnDate(returnDate);
            ReturnDate = returnDate;
        }

        private void GuardBeforeInvalidCar(CarViewModel selectedCar)
        {
            if (selectedCar == null) throw new SelectedCarInvalidException();
        }

        private void GuardBeforeTooYoungDriver(DateTime driverLicenceDate)
        {
            if (DateTime.UtcNow.Year - driverLicenceDate.Year < 3 && SelectedCar.PriceCategory.Category == "Premium") throw new TooYoungDriverException();
            if (driverLicenceDate == DateTime.MinValue) throw new DriverLicenceDataIsInvalidException();
        }

        private void GuardBeforeTooLongKilometers(int kilometers)
        {
            if (kilometers > 10000 || kilometers == null) throw new TooLongKilometersException();
        }

        private void GuardBeforeInvalidRentalDate(DateTime rentalDate)
        {
            if (DateTime.UtcNow.Day > rentalDate.Day || rentalDate == DateTime.MinValue) throw new RentalDateInvalidException();
        }

        private void GuardBeforeInvalidReturnDate(DateTime returnDate)
        {
            if (returnDate.Day < RentalDate.Day || returnDate == DateTime.MinValue) throw new ReturnDateInvalidException();
        }


    }


}
