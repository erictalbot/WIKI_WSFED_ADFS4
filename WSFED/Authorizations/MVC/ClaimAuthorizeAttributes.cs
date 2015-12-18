using System.Web.Mvc;
using System;

namespace WSFED.Authorizations.MVC
{
    /*
     * Complete example to create custom MVC Authorize Attribute :
     * https://simplesecurity.codeplex.com/SourceControl/latest#SimpleSecurity.Filters.Mvc5/AuthorizeAttribute.cs
     * */

    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ClaimAuthorizeAttribute : AuthorizeAttribute
    {
        #region vars

        public string ClaimToCheck { get; set; }

        #endregion

        #region ctor

        public ClaimAuthorizeAttribute()
        {
        }

        #endregion

        #region protected methods

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            return Authorize.AuthorizeAccess(ClaimToCheck, ((System.Security.Claims.ClaimsIdentity)((httpContext.User).Identity)).Claims);
        }

        #endregion
    }
}

