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
    public class CardServiceRepositoryTests
    {
        CardServiceRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new CardServiceRepository(TestServiceManager.Default);
        }

        [TestMethod]
        public async Task GetCardsForDashboardTest()
        {
            var testDashboard = TestData.Dashboards.First();

            var result = await repository.GetCardsForDashboard(testDashboard.Id);

            foreach (var testCard in TestData.Cards[testDashboard.Id])
            {
                Assert.IsTrue(result.Any(r => r.Id == testCard.Id && r.Name == testCard.Name), "for " + testCard.Name);
            }
        }

        [TestMethod]
        public async Task GetCardById()
        {
            var testDashboard = TestData.Dashboards.First();
            var testCard = TestData.Cards[testDashboard.Id].First();

            var result = await repository.GetCardById(testCard.Id);

            Assert.AreEqual(testCard.Name, result.Name);
            Assert.AreEqual(testCard.Id, result.Id);
        }
    }
}
