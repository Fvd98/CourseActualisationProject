using Microsoft.AspNetCore.Authorization;
using OutilsActualisation.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OutilsActualisation.Autorisation
{
    //Source : https://docs.microsoft.com/fr-fr/aspnet/core/security/authorization/policies?view=aspnetcore-2.1
    public class ActualisationHandler : AuthorizationHandler<ActualisationRequirement>
    {
        private OutilActualisationContext _DbContext;

        public ActualisationHandler(OutilActualisationContext DbContext) : base()
        {
            this._DbContext = DbContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ActualisationRequirement requirement)
        {
            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            if (!context.User.HasClaim(c => c.Type == "IDActu") || !context.User.HasClaim(c => c.Type == "RoleActu"))
            {
                return Task.CompletedTask;
            }

            string RoleActu = context.User.FindFirst(c => c.Type == "RoleActu").Value;
            int IDActu = Convert.ToInt32(context.User.FindFirst(c => c.Type == "IDActu").Value);
            if ((_DbContext.UtilisateurActualisation.ToList().FirstOrDefault(UA => UA.Utilisateur == context.User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.Email).Value && UA.Actualisation == IDActu).Rm ?? "AucunRole") == requirement._RequiredRole)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
