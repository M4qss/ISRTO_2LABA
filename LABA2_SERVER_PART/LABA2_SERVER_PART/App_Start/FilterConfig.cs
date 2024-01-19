using System.Web;
using System.Web.Mvc;

namespace LABA2_SERVER_PART
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
