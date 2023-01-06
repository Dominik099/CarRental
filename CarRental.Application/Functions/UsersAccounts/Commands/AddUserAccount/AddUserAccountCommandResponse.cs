using CarRental.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation;

namespace CarRental.Application.Functions.UsersAccounts.Commands.AddUserAccount
{
    public class AddUserAccountCommandResponse : BaseResponse
    {
        public int Id { get; set; }

        public AddUserAccountCommandResponse() : base()
        { }

        public AddUserAccountCommandResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public AddUserAccountCommandResponse(string message)
        : base(message)
        { }

        public AddUserAccountCommandResponse(string message, bool success)
            : base(message, success)
        { }

        public AddUserAccountCommandResponse(int id)
        {
            Id = id;
        }
    }
}
