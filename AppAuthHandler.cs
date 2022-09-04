using Microsoft.AspNetCore.Authorization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
public class AppAuthHandler: Microsoft.AspNetCore.Authorization.IAuthorizationHandler
{
    public async Task HandleAsync(AuthorizationHandlerContext context)
    {
        await Task.CompletedTask;
        if(context.User != null)
        {
            if (context.User.Identity!=null)
            {
                Console.WriteLine($"context.User.Identity.Name={context.User.Identity.Name}");
                Console.WriteLine($"context.User.Identity.IsAuthenticated={context.User.Identity.IsAuthenticated}");                
                Console.WriteLine($"context.User.Identity.IsAuthenticated={context.User.Identity.AuthenticationType}");
            }
        }
        //context.User
        //context.Resource
        //context.Requirements
        //context.HasFailed
        //context.HasSucceeded        
        //context.PendingRequirements
    }
}
 