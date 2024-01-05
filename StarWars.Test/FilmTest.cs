using NUnit.Framework;
using StarWars.Controllers;
using StarWars_Core.Interface;
using StarWars_Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Test
{
    public class FilmTest
    {
        IFilmService _service;
        HttpClient _httpClient;
        FilmController _filmController;
        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
            _service = new FilmService(_httpClient);
            _filmController = new FilmController(_service);
        }
        [Test]
        public void Test1()
        {
            int Expected = 200;
            int? Actual = _filmController.GetFilmById(1).Result.StatusCode;
            Assert.AreEqual(Expected, Actual);
        }
    }
}
