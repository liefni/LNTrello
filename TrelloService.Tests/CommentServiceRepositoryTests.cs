using LNTrello.Models;
using LNTrello.Models.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloService.Tests
{
    [TestClass]
    public class CommentServiceRepositoryTests
    {
        CommentServiceRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new CommentServiceRepository(TestServiceManager.Default);
        }

        [TestMethod]
        public async Task GetCommentsForCardTest()
        {
            var testDashboard = TestData.Dashboards.First();
            var testCard = TestData.Cards[testDashboard.Id].First();

            var result = await repository.GetCommentsForCard(testCard.Id);

            foreach (var testComment in TestData.Comments[testCard.Id])
            {
                Assert.IsTrue(result.Any(r => r.Id == testComment.Id && r.Comment == testComment.Comment), "for " + testCard.Name);
            }
        }

        [TestMethod]
        public async Task AddCommentToCardTest()
        {
            var testDashboard = TestData.Dashboards.First();
            var testCard = TestData.Cards[testDashboard.Id].First();

            var testComment = Guid.NewGuid().ToString();

            await repository.AddCommentToCard(testCard.Id, new CommentModel { Comment = testComment });

            var checkResult = await repository.GetCommentsForCard(testCard.Id);
            Assert.IsTrue(checkResult.Any(c => c.Comment == testComment));
        }
    }
}
