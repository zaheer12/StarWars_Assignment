using NUnit.Framework;
using StarWars_Core.Interface;
using StarWars_Core.Service;
using System.Net.Http;

namespace StarWars.Test
{
    public class PeopleTest
    {
        IPeopleService _service;
        [SetUp]
        public void Setup(HttpClient httpClient)
        {
            _service = new PeopleService(httpClient);
        }

        [Test]
        public void Test1()
        {
            int Expected = 200;
            int? Actual = _service.TestPing().Result.StatusCode;
            Assert.AreEqual(Expected, Actual);
        }
    }
}