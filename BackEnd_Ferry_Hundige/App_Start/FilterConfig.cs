﻿using System.Web;
using System.Web.Mvc;

namespace BackEnd_Ferry_Hundige
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
