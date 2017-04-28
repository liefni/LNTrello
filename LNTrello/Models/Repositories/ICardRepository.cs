using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNTrello.Models.Repositories
{
    public interface ICardRepository
    {

        /// <summary>
        /// Specifies a method to get the cards for the dashboards with the specified id.
        /// </summary>
        /// <param name="dashboardId">The id of the dashboard to get the cards for.</param>
        /// <returns>A task to get an enumerable of the cards for the specified dashboard.</returns>
        Task<IEnumerable<CardModel>> GetCardsForDashboard(string dashboardId);
        
        /// <summary>
        /// Specifies a method to get the card with the specified Id (does not get the cards's comments).
        /// </summary>
        /// <param name="id">The Id of the card to get.</param>
        /// <returns>A task to get the card with the specified Id.</returns>
        Task<CardModel> GetCardById(string id);
    }
}
