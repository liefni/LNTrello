using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace LNTrello.Models.Repositories
{
    public class CardServiceRepository : ICardRepository
    {
        readonly IServiceManager serviceManager;

        public CardServiceRepository(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Gets the card with the specified Id (does not get the cards's comments).
        /// </summary>
        /// <param name="id">The Id of the card to get.</param>
        /// <returns>A task to get the card with the specified Id.</returns>
        public async Task<CardModel> GetCardById(string id)
        {
            CardModel card = null;
            var response = await serviceManager.HttpClient.GetAsync(string.Format("/1/cards/{0}?{1}", id, serviceManager.AuthenticationUrlString));
            response.EnsureSuccessStatusCode2();

            card = await response.Content.ReadAsAsync<CardModel>();
            return card;
        }

        /// <summary>
        /// Gets the cards for the dashboards with the specified id.
        /// </summary>
        /// <param name="dashboardId">The id of the dashboard to get the cards for.</param>
        /// <returns>A task to get an enumerable of the cards for the specified dashboard.</returns>
        public async Task<IEnumerable<CardModel>> GetCardsForDashboard(string dashboardId)
        {
            List<CardModel> cards = null;
            var response = await serviceManager.HttpClient.GetAsync(string.Format("/1/boards/{0}/cards?{1}", dashboardId, serviceManager.AuthenticationUrlString));
            response.EnsureSuccessStatusCode2();

            cards = await response.Content.ReadAsAsync<List<CardModel>>();
            return cards;
        }
    }
}