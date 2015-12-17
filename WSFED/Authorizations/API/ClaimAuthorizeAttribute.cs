using System.Web.Http;
using System.Web.Http.Controllers;
using System.Threading;
using System.Security.Principal;
using System.Linq;


namespace WSFED.Authorizations.WebApi
{
    /*
     * Complete example to create custom WEB API Authorize Attribute :
     * https://simplesecurity.codeplex.com/SourceControl/latest#SimpleSecurity.Filters/BasicAuthorizeAttribute.cs
     * */

    public class ClaimAuthorizeAttribute : AuthorizeAttribute
    {
        #region vars

        public string ClaimToCheck { get; set; }

        #endregion

        #region protected methods

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Action context will not contain the claim or the method decoration.
            // Samething applies to OnAuthorization, which receives an actionContext. Therefore the most simple this to do is to 
            // Get all method within the same controller to use the same decoration.

            IPrincipal client = Thread.CurrentPrincipal;

            string claimToCheck = actionContext.ActionDescriptor.GetCustomAttributes<ClaimAuthorizeAttribute>().First().ClaimToCheck;
            return Authorize.AuthorizeAccess(claimToCheck, ((System.Security.Claims.ClaimsPrincipal)(client)).Claims);
        }

        #endregion
    }
}
