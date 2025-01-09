using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;
using Models;

namespace AppMusicRazor.ModelAuthorization;


public static class MusicGroupOperations
{
    public static OperationAuthorizationRequirement Create =
        new () { Name = nameof(Create) };
    public static OperationAuthorizationRequirement Read =
        new() { Name = nameof(Read) };
    public static OperationAuthorizationRequirement Edit =
        new() { Name = nameof(Edit) };
    public static OperationAuthorizationRequirement Delete =
        new() { Name = nameof(Delete) };
}

public class MusicGroupAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, MusicGroup>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        OperationAuthorizationRequirement requirement, MusicGroup resource)
        {
            //To do operations on MusicGroup you need to be logged in
            if (!context.User.Identity.IsAuthenticated)
            {
                return Task.CompletedTask;
            }

            //Get the specific user logged in
            Guid? userId = null;
            var s = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (s != null)
            {
                userId = Guid.Parse(s);
            }


            //But I can customize Succeed based on
            //requirement, context.User and resource
            if (requirement.Name == MusicGroupOperations.Create.Name)
            {
                context.Succeed(requirement);
            }
            if (requirement.Name == MusicGroupOperations.Read.Name)
            {
                context.Succeed(requirement);
            }
            if (requirement.Name == MusicGroupOperations.Edit.Name)
            {
                context.Succeed(requirement);
            }
            if(requirement.Name == MusicGroupOperations.Delete.Name)
            {
                //I can be very specific, for example only specific userId may delete,
                //for example only those that created the resource (requires MusicGroup model to be updated)
                // var mg = resource;
                // if (userId.HasValue && (userId == Guid.Parse("e3fa4566-b091-4a0f-9ccd-08dd30863295")))
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
}
