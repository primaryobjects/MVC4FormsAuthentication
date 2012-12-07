using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC4FormsAuth.Types.Attributes
{
    public sealed class LogonAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                                     filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            // If the method did not exclusively opt-out of security (via the AllowAnonmousAttribute), then check for an authentication ticket.
            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
}
