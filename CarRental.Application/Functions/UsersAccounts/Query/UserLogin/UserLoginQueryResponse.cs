using CarRental.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.UsersAccounts.Query.UserLogin
{
    public class UserLoginQueryResponse : BaseResponse
    {
        public string Token { get; set; }

        public UserLoginQueryResponse() : base()
        { }

        public UserLoginQueryResponse(ValidationResult validationResult)
            : base(validationResult)
        { }

        public UserLoginQueryResponse(string message)
        : base(message)
        {
            Token = message;
        }

        public UserLoginQueryResponse(string message, bool success)
            : base(message, success)
        { }
    }
}
