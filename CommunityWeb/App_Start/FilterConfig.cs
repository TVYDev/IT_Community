using System.Web;
using System.Web.Mvc;

namespace CommunityWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Add this to make HTTPS is Require to access to website
            filters.Add(new RequireHttpsAttribute());

        }
    }
}
