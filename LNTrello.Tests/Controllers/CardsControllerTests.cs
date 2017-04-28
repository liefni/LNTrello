using LNTrello.Controllers;
using LNTrello.Models;
using LNTrello.Models.Repositories;
using LNTrello.Tests.TestRepositories;
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
    public class CardsControllerTests
    {
        CardsController controller;
        CardTestRepository cardRepository;
        CommentTestRepository commentRepository;

        [TestInitialize]
        public void Initialize()
        {
            cardRepository = new CardTestRepository();
            commentRepository = new CommentTestRepository();
            controller = new CardsController(cardRepository, commentRepository);
        }

        [TestMethod]
        public async Task AddComment_Get_Test()
        {
            var cardId = "58ffd0baa826642823a7fecf";
            var result = await controller.AddComment(cardId);
            Assert.AreEqual("Card 1", controller.ViewBag.cardName);
            Assert.AreEqual(cardId, controller.ViewBag.Id);
        }

        [TestMethod]
        public async Task AddComment_Post_Test()
        {
            var cardId = "58ffd0baa826642823a7fecf";
            var comment = "Unit test comment";
            var result = await controller.AddComment(new CommentModel { Comment = comment, Id = "testid" }, cardId);

            var comments = await commentRepository.GetCommentsForCard(cardId);
            Assert.IsTrue(comments.Any(c => c.Comment == comment));
            Assert.IsTrue(result is RedirectToRouteResult);
        }

        [TestMethod]
        public async Task AddComment_Post_InvalidTest()
        {
            var cardId = "58ffd0baa826642823a7fecf";
            var comment = "Unit test comment";
            controller.ModelState.AddModelError("Comment", "Comment is required");
            var result = await controller.AddComment(new CommentModel { Comment = comment, Id = "testid2" }, cardId);

            var comments = await commentRepository.GetCommentsForCard(cardId);
            Assert.IsFalse(comments.Any(c => c.Comment == comment && c.Id == "testid2"));
            Assert.AreEqual("Card 1", controller.ViewBag.CardName);
            Assert.AreEqual(cardId, controller.ViewBag.Id);

            Assert.IsTrue(result is ViewResult);
        }
    }
}
