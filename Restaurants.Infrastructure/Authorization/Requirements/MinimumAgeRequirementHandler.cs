﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;

namespace Restaurants.Infrastructure.Authorization.Requirements
{
    public class MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger,
        IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            MinimumAgeRequirement requirement)
        {
            var currentUser = userContext.GetCurrentUser();

            logger.LogInformation($"User: {currentUser.Email}, date of birth {currentUser.DateOfBirth} - Handling MinimumAgeRequirement");

            if(currentUser.DateOfBirth == null)
            {
                logger.LogWarning("Authorization failed: Date of birth is not set");
                context.Fail();
                return Task.CompletedTask;
            }

            if(currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
            {
                logger.LogInformation("Authorization succeeded");
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
