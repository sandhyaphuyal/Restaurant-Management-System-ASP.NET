using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication16.Helper
{
    public static class SessionHelper
    {
        public static void SetSession(SystemInfoForSession systemInfoForSession)
        {
            HttpContext.Current.Session["SystemInfoForSession"] = systemInfoForSession;
        }

        public static SystemInfoForSession GetSession()
        {
            return (SystemInfoForSession)HttpContext.Current.Session["SystemInfoForSession"];
        }
    }
}