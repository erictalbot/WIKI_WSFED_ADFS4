using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace WSFED.Authorizations
{
    public static class Authorize
    {
        public static bool AuthorizeAccess(string claimToCheck, IEnumerable<Claim> claims)
        {
            if (!string.IsNullOrWhiteSpace(claimToCheck))
                return claims.Any(c => String.Compare(c.Value, claimToCheck, StringComparison.InvariantCultureIgnoreCase) == 0);
            return false;
        }

        public static bool AuthorizeAccess(string claimToCheck, System.Security.Claims.ClaimsIdentity identity)
        {
            return Authorize.AuthorizeAccess(claimToCheck, identity.Claims);
        }
    }
}
