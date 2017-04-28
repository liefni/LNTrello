using LNTrello.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace LNTrello.Filters
{
    public class ServiceExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is UnauthorisedException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new RedirectResult("/Authentication/Login?returnUrl=" + filterContext.HttpContext.Request.RawUrl);
            }

            else if (filterContext.Exception is ResourceNotFoundException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult
                {
                    ViewName = "NotFound",
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData
                };
            }

            else if (filterContext.Exception is HttpRequestException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new ViewResult
                {
                    ViewName = "TrelloError",
                    ViewData = filterContext.Controller.ViewData,
                    TempData = filterContext.Controller.TempData
                };
            }
        }
    }
}