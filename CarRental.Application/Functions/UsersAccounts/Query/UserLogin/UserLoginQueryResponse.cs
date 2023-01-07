using CarRental.Application.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.UsersAccounts.Query.UserLogin
{
    public class UserLoginQueryResponse 
    {
        public string Token { get; set; }

        public UserLoginQueryResponse() 
        { }
    }
}
