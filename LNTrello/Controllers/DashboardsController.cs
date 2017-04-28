using LNTrello.Filters;
using LNTrello.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LNTrello.Controllers
{
    [ServiceExceptionFilter]
    public class DashboardsController : Controller
    {
        private IDashboardRepository dashboradRepository;
        private ICardRepository cardRepository;

        public DashboardsController(IDashboardRepository dashboradRepository, ICardRepository cardRepository)
        {
            this.dashboradRepository = dashboradRepository;
            this.cardRepository = cardRepository;
        }

        public async Task<ActionResult> Index()
        {
            var dashboards = await dashboradRepository.GetDashboards();
            return View(dashboards);
        }

        public async Task<ActionResult> Dashboard(string id)
        {
            var dashboard = await dashboradRepository.GetDashboardById(id);
            dashboard.Cards = await cardRepository.GetCardsForDashboard(id);

            return View(dashboard);
        }
    }
}