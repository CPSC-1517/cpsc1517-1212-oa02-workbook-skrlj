using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulationDemo
{
    public class HockeyPlayer
    {
        public string PlayerName { get; set; }
        public int GamesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Points { get { return Goals + Assists; } }

        public HockeyPlayer(string playerName, int gamesPlayed, int goals, int assists)
        {
            PlayerName = playerName;
            GamesPlayed = gamesPlayed;
            Goals = goals;
            Assists = assists;
        }

        public HockeyPlayer()
        {
            PlayerName = "";
            GamesPlayed = 0;
            Goals = 0;
            Assists = 0;
        }

        public override string ToString()
        {
            return $"{PlayerName},{GamesPlayed},{Goals},{Assists}";
        }
    }
}
