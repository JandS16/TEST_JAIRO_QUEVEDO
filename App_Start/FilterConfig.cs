﻿using System.Web;
using System.Web.Mvc;

namespace TEST_JAIRO_QUEVEDO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
