using System.Web;
using System.Web.Mvc;

namespace Projet_de_fin_de_formation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
