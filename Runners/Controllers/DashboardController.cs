using Microsoft.AspNetCore.Mvc;
using Runners.Interfaces;
using Runners.Data;
using Runners.ViewModels;

namespace Runners.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRespository;

        public DashboardController(IDashboardRepository dashboardRespository)
        {
            _dashboardRespository = dashboardRespository;
        }
        public async Task<IActionResult> Index()
        {
            var userRaces = await _dashboardRespository.GetAllUserRaces();
            var userClubs = await _dashboardRespository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                Races = userRaces,
                Clubs = userClubs
            };
            return View(dashboardViewModel);
        }
    }
}
