using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.IO;

using System.Threading;

namespace CBSP.Common
{
    public class BaseController : Controller
    {
        
       
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            var exception = filterContext.Exception;
            if (exception == null)
            {
                return;
            }

            /*
            string filepath = Server.MapPath("~/Log/");
            string filename = DateTime.Now.ToString("yyyy-MM-dd");
            string fullname = filepath + filename + ".txt";
            System.IO.File.AppendAllText(fullname, exception.Message, System.Text.Encoding.UTF8);
            System.IO.File.AppendAllText(fullname, "\r\n", System.Text.Encoding.UTF8);
            System.IO.File.AppendAllText(fullname, exception.StackTrace, System.Text.Encoding.UTF8);
            System.IO.File.AppendAllText(fullname, "\r\n", System.Text.Encoding.UTF8);

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/Index");
            */
        }


        protected override void OnActionExecuted(ActionExecutedContext filterContext)//protected 只能被子类访问
        {
            base.OnActionExecuted(filterContext);

        }
    }
}