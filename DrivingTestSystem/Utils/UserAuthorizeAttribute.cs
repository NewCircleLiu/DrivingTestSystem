﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DrivingTestSystem.Utils
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        //用户授权规则
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpRequestBase r = httpContext.Request;
            if (httpContext.Session["User"] == null)
            {
                return false;
            }
            return true;
        }
        //处理未能授权的情况
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            
            filterContext.Result = new RedirectResult("~/UserLogin/Index/");
        }
    }
}