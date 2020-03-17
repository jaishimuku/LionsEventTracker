using LionsEventTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LionsEventTracker
{
    //public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    //{
    //    public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
    //    {
    //        context.Validated();
    //    }
    //    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    //    {
    //        //var userStore = new UserStore<User>(new DatabaseContext());
    //        //var manager = new UserManager<User>(userStore);

    //        var user = await manager.FindAsync(context.UserName, context.Password);
    //        if (user != null)
    //        {
    //            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    //            identity.AddClaim(new Claim("FirstName", user.FirstName));
    //            identity.AddClaim(new Claim("LastName", user.LastName));
    //            identity.AddClaim(new Claim("UserName", user.UserName));
    //            identity.AddClaim(new Claim("Email", user.Email));
    //            context.Validated(identity);
    //        }
    //        else
    //            return;
    //    }
        
    //}
}
 