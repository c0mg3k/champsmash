using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampSmash.Models.DataPopulation
{
    public class Champion
    {
        private ImageConverter imageConverter = new ImageConverter();
        public int ID { get; set; }
        public string Key { get; set; }
        public int RiotID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public Champion(RiotSharp.Endpoints.StaticDataEndpoint.Champion.ChampionStatic champion)
        {
            RiotID = champion.Id;
            Name = champion.Name;
            Key = champion.Key;
        }
    }
}