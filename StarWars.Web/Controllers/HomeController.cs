using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWars.Web.Common;
using StarWars.Web.Interface;
using StarWars.Web.Model;
using StarWars.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPeopleService _peopleService;
        private readonly IFilmService _filmService;

        public HomeController(ILogger<HomeController> logger, IPeopleService peopleService, IFilmService filmService)
        {
            _logger = logger;
            _peopleService = peopleService;
            _filmService = filmService;
        }

        public IActionResult Index()
        {
            var data = _peopleService.GetMultiplePeople().Result;
            List<PeopleModel> PeopleModel = null;
            if (data.StatusCode == Constants.ResponseStatusCode.Success)
            {
                PeopleModel = data.Data.ToList();
            }
            else
            {
                ViewBag.Error = data.Message;
            }

            return View(PeopleModel);
        }

        public IActionResult People(string Id)
        {
            var data = _peopleService.GetPeopleById(Id).Result;
            PeopleModel PeopleModel = null;
            if (data.StatusCode == Constants.ResponseStatusCode.Success)
            {
                PeopleModel = data.Data;
            }
            else
            {
                ViewBag.Error = data.Message;
            }

            return View(PeopleModel);
        }
        public IActionResult Film(string Id)
        {
            var data = _filmService.GetFilmById(Id).Result;
            FilmModel FilmModel = null;
            if (data.StatusCode == Constants.ResponseStatusCode.Success)
            {
                FilmModel = data.Data;
            }
            else
            {
                ViewBag.Error = data.Message;
            }

            return View(FilmModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
