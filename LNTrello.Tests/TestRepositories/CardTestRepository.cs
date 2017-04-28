using LNTrello.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LNTrello.Models;

namespace LNTrello.Tests.TestRepositories
{
    public class CardTestRepository : ICardRepository
    {
        public static Dictionary<string, List<CardModel>> Cards = new Dictionary<string, List<CardModel>>
        {
            { "58ffd06c27a663698d77e65b", new List<CardModel> { new CardModel { Id = "58ffd0baa826642823a7fecf", Name = "Card 1" } } }
        };

        public async Task<CardModel> GetCardById(string id)
        {
            foreach (var cardPair in Cards)
            {
                var card = cardPair.Value.FirstOrDefault(c => c.Id == id);
                if (card != null)
                    return card;
            }
            return null;
        }

        public async Task<IEnumerable<CardModel>> GetCardsForDashboard(string dashboardId)
        {
            return Cards[dashboardId];
        }
    }
}
