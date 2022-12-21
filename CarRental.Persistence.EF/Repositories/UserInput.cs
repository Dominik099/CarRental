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
            SelectedCar = selectedCar;
            EstimatedKilometers = estimadedKilometers;
            GuardBeforeTooYoungDriver(driverLicence);
            DriverLicenceDate = driverLicence;
            RentalDate = rentalDate;
            ReturnDate = returnDate;
        }

        private void GuardBeforeTooYoungDriver(DateTime driverLicenceDate)
        {
            if (DateTime.UtcNow.Year - driverLicenceDate.Year < 3 && SelectedCar.PriceCategory.Category == "Premium") throw new TooYoungDriverException();
            if (driverLicenceDate == DateTime.MinValue) throw new DriverLicenceDataIsInvalidException();
        }


    }


}
