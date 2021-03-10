using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutilsActualisation.Autorisation
{
    //Source : https://docs.microsoft.com/fr-fr/aspnet/core/security/authorization/policies?view=aspnetcore-2.1
    public class ActualisationRequirement : IAuthorizationRequirement
    {
        public string _RequiredRole { get; private set; }

        public ActualisationRequirement(string RequiredRole)
        {
            _RequiredRole = RequiredRole;
        }
    }
}
