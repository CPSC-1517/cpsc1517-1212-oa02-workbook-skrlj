using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class HockeyTeam
    {
        // Define a computed (read-only) property for TotalPoints
        public int TotalPoints
        {
            get
            {
                int sum = 0;

                foreach (HockeyPlayer currentPlayer in HockeyPlayers)
                {
                    sum += currentPlayer.Points;
                }

                return sum;
            }
        }

        // Define a fully-implemented property with a backing field for the Team Name
        private string _teamName; // Define a private backing field for the property

        public string TeamName // Define a read-only property for TeamName with a private set
        {
            get { return _teamName; }

            private set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("HockeyTeam TeamName cannot be empty, null, or a whitespace");
                }

                // Validate the new team name to be at least 5 characters long
                if (value.Trim().Length < 5)
                {
                    throw new ArgumentException("HockeyTeam TeamName must contain 5 or more characters");
                }
                _teamName = value;
            }
        }

        // Define an auto-implemented property with a private set for the team division
        public TeamDivision Division { get; private set; }

        // Define an auto-implemented readonly property for the HockeyPlayers
        public List<HockeyPlayer> HockeyPlayers { get; } = new List<HockeyPlayer>();

        // Define a readonly property for PlayerCount
        public int PlayerCount
        {
            get { return HockeyPlayers.Count;}
        }

        // Define a readonly property with a private set for the coach
        // The Coach property is known as Aggregation/Composition (when the field/property) is not
        // a value type. Composition is a specified version of aggregation meaning that it cannot
        // exist on its own.
        public HockeyCoach Coach { get; private set; }

        // Define a greedy constructor that has a parameter for the TeamName, TeamDivision, and Coach
        #pragma warning disable
        public HockeyTeam(string teamName, TeamDivision division, HockeyCoach coach)
        {
            TeamName = teamName;
            Division = division;
            Coach = coach;
        }

        // Define a method that will add a HockeyPlayer to the team
        public void AddPlayer(HockeyPlayer player)
        {
            // Validate that the player is not null
            if (player == null)
            {
                throw new ArgumentException("HockeyTeam HockeyPlayer is required");
            }

            // Validate that the number of players is less than 23
            if (HockeyPlayers.Count == 23)
            {
                throw new InvalidOperationException("HockeyTeam HockeyPlayers cannot exceed 23");
            }

            // Validate that the player (by primary number) is not already on the team
            foreach(var currentPlayer in HockeyPlayers)
            {
                if (currentPlayer.PrimaryNumber == player.PrimaryNumber)
                {
                    throw new Exception("HockeyTeam HockeyPlayers cannot have the same PrimaryNumber");
                }
            }

            HockeyPlayers.Add(player);
        }

        public void RemovePlayer() { }

    }
}
