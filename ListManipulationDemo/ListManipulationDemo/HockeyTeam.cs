using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulationDemo
{
    public class HockeyTeam
    {
        public string TeamName { get; private set; }
        public List<HockeyPlayer> Players { get; }
        public HockeyTeam(string teamName)
        {
            TeamName = teamName;

            Players = new List<HockeyPlayer>
            {
                new HockeyPlayer { PlayerName = "Leon Draisaitl", GamesPlayed = 46, Goals = 33, Assists = 32 },
                new HockeyPlayer { PlayerName = "Connor McDavid", GamesPlayed = 45, Goals = 24, Assists = 40 },
                new HockeyPlayer { PlayerName = "Ryan Nugent-Hopkins", GamesPlayed = 39, Goals = 6, Assists = 28 },
                new HockeyPlayer { PlayerName = "Zach Hyman", GamesPlayed = 40, Goals = 14, Assists = 13 },
                new HockeyPlayer { PlayerName = "Jesse Puljujarvi", GamesPlayed = 44, Goals = 11, Assists = 15 },
                new HockeyPlayer { PlayerName = "Evan Bouchard", GamesPlayed = 46, Goals = 9, Assists = 17 },
                new HockeyPlayer { PlayerName = "Darnell Nurse", GamesPlayed = 39, Goals = 5, Assists = 15 },
                new HockeyPlayer { PlayerName = "Tyson Barrie", GamesPlayed = 40, Goals = 3, Assists = 14 }
            };
        }

        public List<HockeyPlayer> Split(int startIndex)
        {
            List<HockeyPlayer> splittedPlayers = new();

            for (int index = startIndex; index < Players.Count; index++)
            {
                splittedPlayers.Add(Players[index]);
            }

            Players.RemoveRange(startIndex, Players.Count - startIndex);
            return splittedPlayers;
        }

        public List<HockeyPlayer> Split(string playerName)
        {
            int indexOfPlayerName = 0;
            for (int index = 0; index < Players.Count; index++)
            {
                if(Players[index].PlayerName == playerName)
                {
                    indexOfPlayerName = index;
                    index = Players.Count;
                }
            }

            return Split(indexOfPlayerName);

            //foreach (var player in Players)
            //{
            //    if (player.PlayerName == playerName)
            //    {
            //        int indexOfPlayerName = Players.IndexOf(player);
            //        Players.RemoveRange(0, indexOfPlayerName);
            //        return Players;
            //    }
            //}
        }
    }
}
