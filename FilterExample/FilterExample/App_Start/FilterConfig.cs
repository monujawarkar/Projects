using System.Web;
using System.Web.Mvc;

namespace FilterExample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute
            {
                ExceptionType = typeof(System.Data.DataException),
                View = "CommonLogError"
            });
            filters.Add(new HandleErrorAttribute());
        }
    }
}
