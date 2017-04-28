using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNTrello.Models.Repositories
{
    public interface IDashboardRepository
    {
        /// <summary>
        /// Specifies a method to get all dashboards for the current user.
        /// </summary>
        /// <returns>A task to get an enumerable of the users dashboards.</returns>
        Task<IEnumerable<DashboardModel>> GetDashboards();

        /// <summary>
        /// Specifies a method to get the dashboard with the specified Id (does not get the dashboard's cards).
        /// </summary>
        /// <param name="id">The id of the dashboard to get.</param>
        /// <returns>A task to get the dashboard with the specified Id.</returns>
        Task<DashboardModel> GetDashboardById(string id); 
    }
}
