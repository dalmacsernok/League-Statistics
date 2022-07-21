using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using Codecool.LeagueStatistics.Factory;
using Codecool.LeagueStatistics.Model;
using Codecool.LeagueStatistics.View;

namespace Codecool.LeagueStatistics.Controllers
{
    /// <summary>
    ///     Provides all necessary methods for season simulation
    /// </summary>
    public class Season
    {
        public List<Team> League { get; set; }

        public Season()
        {
            League = new List<Team>();
        }

        /// <summary>
        ///     Fills league with new teams and simulates all games in season.
        /// After all games played calls table to be displayed.
        /// </summary>
        public void Run()
        {
            var league = LeagueFactory.CreateLeague(6);
            foreach (var team in league)
            {
                League.Add(team);
            }
            PlayAllGames();

            // Call Display methods here
        }
        /// <summary>
        ///     Playing one round. Everyone with everyone one time. 
        /// </summary>
        public void PlayAllGames()
        {
            for (int i = 0; i < League.Count; i++)
            {
                for (int j = i + 1; i < League.Count; i++)
                {
                    PlayMatch(League[i], League[j]);
                }
            }
        }
        /// <summary>
        ///     Plays single game between two teams and displays result after.
        /// </summary>
        public void PlayMatch(Team team1, Team team2)
        {
            int team1Score = ScoredGoals(team1);
            int team2Score = ScoredGoals(team2);
            if (team1Score > team2Score)
            {
                team1.Wins++;
            } else if (team2Score > team1Score)
            {
                team2.Wins++;
            }
            else
            {
                team1.Draws++;
                team2.Draws++;
            }

            Display.SingleMatchResult(team1, team2);
            Thread.Sleep(1000);
            Console.Clear();
        }

        /// <summary>
        ///     Checks for each player of given team chance to score based on skillrate.
        ///     Adds scored goals to player's and team's statistics.
        /// </summary>
        /// <param name="team">team</param>
        /// <returns>All goals scored by the team in current game</returns>
        public int ScoredGoals(Team team)
        {
            int goals = 0;
            int chance = Utils.Random.Next(0, 101);
            foreach (Player player in team.Players)
            {
                if (player.SkillRate >= chance)
                {
                    player.Goals++;
                }
            }

            return goals;

        }
    }
}
