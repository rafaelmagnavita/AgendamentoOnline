using AgendamentoOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendamentoOnline.Utils
{
    public class Filters
    {

        public class SessionExpiredCheckAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                User user = (User)HttpContext.Current.Session["user"];
                if (user == null)
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }

        public class ADMFILTER : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                User user = (User)HttpContext.Current.Session["user"];
                if (!(user is AdminUser))
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }
        public class DOCFILTER : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                User user = (User)HttpContext.Current.Session["user"];
                if (!(user is Coach))
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }

        public class ATTFILTER : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                User user = (User)HttpContext.Current.Session["user"];
                if (!(user is Attendant))
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }

        public class PATFILTER : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                User user = (User)HttpContext.Current.Session["user"];
                if (!(user is Client))
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }

        public class NOTPATFILTER : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                User user = (User)HttpContext.Current.Session["user"];
                if (user is Client)
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
}