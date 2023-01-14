﻿using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application;

namespace CarRental.Application.Authorization.AuthorizationByCarAddressOwner
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, CarAddress>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, CarAddress carAddress)
        {
            if(requirement.ResourceOperation == ResourceOperation.Get || 
                requirement.ResourceOperation == ResourceOperation.Add)
            {
                context.Succeed(requirement);
            }
            
            var userId = context.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            if (carAddress.AddedById == int.Parse(userId))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
