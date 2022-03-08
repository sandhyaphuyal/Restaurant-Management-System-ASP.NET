using System.Web;
using System.Web.Mvc;
using WebApplication16.Helper;

namespace WebApplication16
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomAuthenticationAttribute());
        }
    }
}
