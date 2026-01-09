using System.Web;
using System.Web.Mvc;

namespace Filters_Project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new Models.LOGCUSTOM_EXCEPTION());  // globally registring custom filter level 1
        }
    }
}
