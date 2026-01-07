using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTML_HELPER_PRJ.Custom_Helpers
{
    public static class CustomExtensionHelper
    {
        public static IHtmlString RedLabel(this HtmlHelper htmlHelperobj, string content)
        {
            string str = string.Format("<label><i><font color=red>{0}</font></i></label>", content);
            return new HtmlString(str);
        }
        public static IHtmlString GreenLabel(this HtmlHelper htmlHelperobj, string content)
        {
            string str = string.Format("<label><i><font color=green>{0}</font></i></label>", content);
            return new HtmlString(str);
        }
    }
}