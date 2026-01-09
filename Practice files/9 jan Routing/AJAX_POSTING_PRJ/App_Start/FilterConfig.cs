using System.Web;
using System.Web.Mvc;

namespace AJAX_POSTING_PRJ
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
