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
    public class AddUserAccountCommandResponse
    {
        public int Id { get; set; }

        public AddUserAccountCommandResponse() : base()
        { }

    }
}
