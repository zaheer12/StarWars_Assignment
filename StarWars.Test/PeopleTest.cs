using NUnit.Framework;
using StarWars.Controllers;
using StarWars_Core.Interface;
using StarWars_Core.Service;
using System;
using System.Net.Http;

namespace StarWars.Test
{
    public class PeopleTest
    {
        IPeopleService _service;
        HttpClient _httpClient;
        PeopleController _peopleController;
        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://swapi.dev/api/");
            _service = new PeopleService(_httpClient);
            _peopleController = new PeopleController(_service);
        }

        [Test]
        public void Test1()
        {
            int Expected = 200;
            int? Actual = _peopleController.TestPing().Result.StatusCode;
            Assert.AreEqual(Expected, Actual);
        }
        [Test]
        public void GetPeopleById_get_people_from_proxyapi()
        {
            int Expected = 200;
            int? Actual = _peopleController.GetPeopleById(1).Result.StatusCode;
            Assert.AreEqual(Expected, Actual);
        }
        [Test]
        public void GetMultiplePeople_get_people_from_proxyapi()
        {
            int Expected = 200;
            int? Actual = _peopleController.GetMultiplePeople().Result.StatusCode;
            Assert.AreEqual(Expected, Actual);
        }




    }
}