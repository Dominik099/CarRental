using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.UsersAccounts.Commands
{
    public class AddUserAccountCommand : IRequest<AddUserAccountCommandResponse>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DriverLicenseDate { get; set; }
        public string Password { get; set; }
        public string Pesel { get; set; }
    }
}
