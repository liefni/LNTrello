using LNTrello.Models;
using LNTrello.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LNTrello.Controllers
{
    public class AuthenticationController : Controller
    {
        private IServiceManager serviceManager;

        public AuthenticationController(IServiceManager serviceProvider)
        {
            this.serviceManager = serviceProvider;
        }
        
        // GET: Authentication
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthenticationModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                serviceManager.UserToken = model.UserToken;
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url == null || Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Dashboards");
        }

        public ActionResult Logout()
        {
            serviceManager.UserToken = null;
            return RedirectToAction("Login");
        }
    }
}