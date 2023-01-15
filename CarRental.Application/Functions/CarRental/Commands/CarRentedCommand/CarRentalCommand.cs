using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarRental.Commands.CarRentedCommand
{
    public class CarRentalCommand : IRequest<CarRentalCommandResponse>
    {
        public int CarId { get; set; }
        public DateTime DriverLicenseDate { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
