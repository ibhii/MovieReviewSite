﻿using Microsoft.AspNetCore.Authorization;

namespace MovieReviewSite.Core.ConfigServices;

public class RoleRequirementHandler
{
}
//     : AuthorizationHandler<RoleRequirement>
// {
//     protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
//     {
//         if (context.User.IsInRole(requirement.Role))
//         {
//             context.Succeed(requirement);
//         }
//
//         return Task.CompletedTask;
//     }
// }
