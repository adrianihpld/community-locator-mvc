using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Runners.Data;
using Runners.Interfaces;
using Runners.Models;

namespace Runners.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRespository;

        public RaceController(IRaceRepository raceRespository)
        {
            _raceRespository = raceRespository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRespository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRespository.GetByIdAsync(id);
            return View(race);
        }
    }
}