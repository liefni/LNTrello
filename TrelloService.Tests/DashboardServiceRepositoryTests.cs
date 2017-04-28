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
    public class DashboardServiceRepositoryTests
    {
        DashboardServiceRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new DashboardServiceRepository(TestServiceManager.Default);
        }

        [TestMethod]
        public async Task GetDashboardsTests()
        {
            var result = await repository.GetDashboards();

            foreach (var testDashboard in TestData.Dashboards)
            {
                Assert.IsTrue(result.Any(r => r.Id == testDashboard.Id && r.Name == testDashboard.Name), "for " + testDashboard.Name);
            }
        }

        [TestMethod]
        public async Task GetDashboardByIdTest()
        {
            var testDashboard = TestData.Dashboards.First();
            var result = await repository.GetDashboardById(testDashboard.Id);

            Assert.AreEqual(testDashboard.Name, result.Name);
            Assert.AreEqual(testDashboard.Id, result.Id);
        }
    }
}
