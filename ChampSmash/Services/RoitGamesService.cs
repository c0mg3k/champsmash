using RiotSharp;
using RiotSharp.Endpoints.ChampionEndpoint;
using RiotSharp.Endpoints.StaticDataEndpoint.Champion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChampSmash.Services
{
    public class RiotGamesService
    {

        private readonly RiotApi _api;
        private readonly string _latestVersion;
        public RiotGamesService()
        {
            _api = RiotApi.GetDevelopmentInstance("RGAPI-12ce1226-a71e-419a-a17e-3136949105b0");
        }
        public async Task<ChampionListStatic> GetChampions()
        {
            var result = await _api.StaticData.Champions.GetAllAsync(_latestVersion, RiotSharp.Misc.Language.en_US, true);

            return result;
        }
    }
}
