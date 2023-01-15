using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Authorization.AgeAuthorization
{
    public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var dateOfBirth = DateTime.Parse(context.User.FindFirst(x => x.Type == "DateOfBirth").Value);

            if(dateOfBirth.AddYears(requirement.MinimumAge) <= DateTime.Today)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
