﻿using System.Web;
using System.Web.Mvc;

namespace NgocThuy_Lab4_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
