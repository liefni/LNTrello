using LNTrello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloService.Tests
{
    // This data contains the expected data to be received from the webservice. This will need to be updated 
    // to match the actual data in the accociated trello account to be able to test the webservice.
    static class TestData
    {
        public static List<DashboardModel> Dashboards = new List<DashboardModel>
        {
            new DashboardModel { Id = "58ffd06c27a663698d77e65b", Name = "Test Board" }
        };

        public static Dictionary<string, List<CardModel>> Cards = new Dictionary<string, List<CardModel>>
        {
            { "58ffd06c27a663698d77e65b", new List<CardModel> { new CardModel { Id = "58ffd0baa826642823a7fecf", Name = "Card 1" } } }
        };

        public static Dictionary<string, List<CommentModel>> Comments = new Dictionary<string, List<CommentModel>>
        {
            { "58ffd0baa826642823a7fecf", new List<CommentModel> { new CommentModel { Id = "5901571e8e5e548f25d17782", Comment = "Test comment for Card 1" } } }
        };
    }
}
