using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChampSmash.Models.Riot
{
    public class RiotResponse
    {
        public string Type { get; set; }
        public string Format { get; set; }
        public string Version { get; set; }
        public List<RiotChampion> Data { get; set; }
    }
}
