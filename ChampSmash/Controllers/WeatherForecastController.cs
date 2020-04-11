using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ChampSmash.Models.DataPopulation;
using ChampSmash.Models.Riot;
using ChampSmash.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiotSharp;

namespace ChampSmash.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var request = HttpWebRequest.Create(@"http://ddragon.leagueoflegends.com/cdn/img/champion/loading/Aatrox_0.jpg");
            var result = request.GetResponse();
            var rng = new Random();
            var latestVersion = "10.1.1";
            var stuff = RiotSharp.RiotApi.GetDevelopmentInstance("RGAPI-12ce1226-a71e-419a-a17e-3136949105b0");
            var champs = stuff.StaticData.Champions.GetAllAsync(latestVersion).Result.Champions.Values;
            var img = stuff.StaticData.Champions.GetByKeyAsync("Aatrox", latestVersion, RiotSharp.Misc.Language.en_US).Result.Image;
            List<Champion> localChamps = new List<Champion>();
            foreach(var champ in champs)
            {
                localChamps.Add(new Champion(champ));
            }
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
