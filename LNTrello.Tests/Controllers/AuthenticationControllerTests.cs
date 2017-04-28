using LNTrello.Controllers;
using LNTrello.Models;
using LNTrello.Models.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LNTrello.Tests.Controllers
{
    [TestClass]
    public class AuthenticationControllerTests
    {
        AuthenticationController controller;
        IServiceManager serviceManager;

        [TestInitialize]
        public void Initialize()
        {
            serviceManager = new TestServiceManager();
            controller = new AuthenticationController(serviceManager);
        }

        [TestMethod]
        public void Login_Get_Test()
        {
            var testPath = "/return/path";
            controller.Login(testPath);
            Assert.AreEqual(testPath, controller.ViewBag.ReturnUrl);
        }

        [TestMethod]
        public void Login_Post_Test()
        {
            var testPath = "/return/path";
            var result = controller.Login(new AuthenticationModel { UserToken = "TestToken" }, testPath);

            Assert.IsTrue(result is RedirectResult);
            Assert.AreEqual(testPath, (result as RedirectResult).Url);
        }

        [TestMethod]
        public void Login_Post_InvalidTest()
        {
            controller.ModelState.AddModelError("UserToken", "User Token is required");
            var result = controller.Login(new AuthenticationModel(), "/");

            Assert.IsTrue(result is ViewResult);
            Assert.AreEqual("/", controller.ViewBag.ReturnUrl);
        }

        [TestMethod]
        public void Logout_Test()
        {
            var result = controller.Logout();
            Assert.AreEqual(null, serviceManager.UserToken);
            Assert.IsTrue(result is RedirectToRouteResult);
        }
    }
}
