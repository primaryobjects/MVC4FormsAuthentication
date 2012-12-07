using MVC4FormsAuth.Types.Attributes;
using System.Web;
using System.Web.Mvc;

namespace MVC4FormsAuth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Add controller security (AllowAnonymousAttribute).
            filters.Add(new LogonAuthorize());
        }
    }
}