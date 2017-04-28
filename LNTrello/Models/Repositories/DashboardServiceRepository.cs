using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LNTrello.Models.Repositories
{
    public class DashboardServiceRepository : IDashboardRepository
    {
        readonly IServiceManager serviceManager;

        public DashboardServiceRepository(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Gets the dashboard with the specified Id (does not get the dashboard's cards).
        /// </summary>
        /// <param name="id">The id of the dashboard to get.</param>
        /// <returns>A task to get the dashboard with the specified Id.</returns>
        public async Task<DashboardModel> GetDashboardById(string id)
        {
            DashboardModel dashboard = null;
            var response = await serviceManager.HttpClient.GetAsync(string.Format("/1/boards/{0}?{1}", id, serviceManager.AuthenticationUrlString));
            response.EnsureSuccessStatusCode2();

            dashboard = await response.Content.ReadAsAsync<DashboardModel>();
            return dashboard;
        }

        /// <summary>
        /// Gets all dashboards for the current user.
        /// </summary>
        /// <returns>A task to get an enumerable of the users dashboards.</returns>
        public async Task<IEnumerable<DashboardModel>> GetDashboards()
        {
            List<DashboardModel> dashboards = null;
            var response = await serviceManager.HttpClient.GetAsync("/1/members/me/boards?" + serviceManager.AuthenticationUrlString);
            response.EnsureSuccessStatusCode2();

            dashboards = await response.Content.ReadAsAsync<List<DashboardModel>>();
            return dashboards;
        }
    }
}