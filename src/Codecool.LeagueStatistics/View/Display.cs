using Codecool.LeagueStatistics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTables;

namespace Codecool.LeagueStatistics.View
{
    /// <summary>
    /// Provides console view for league table, results and all League statistics
    /// </summary>
    public static class Display
    {
        public static void LeagueResult(IEnumerable<Team> teams)
        {
            int counter = 1;
            var table = new ConsoleTable("Place", "Team's name", "Points", "Goals", "Wins", "Draws", "Losses");

            foreach (Team team in teams)
            {
                table.AddRow($"{counter}.", team.Name, team.CurrentPoints, team.Players.Sum(player => player.Goals), team.Wins, team.Draws, team.Losts);
                counter++;
            }
            Console.WriteLine(table);
        }

        public static void SingleMatchResult(Team team1, Team team2)
        {
            var table = new ConsoleTable("Team's name", "Points", "Goals", "Wins", "Draws", "Losses");

            table.AddRow(team1.Name, team1.CurrentPoints, team1.Players.Sum(player => player.Goals), team1.Wins, team1.Draws, team1.Losts);
            table.AddRow(team2.Name, team2.CurrentPoints, team2.Players.Sum(player => player.Goals), team2.Wins, team2.Draws, team2.Losts);

            Console.WriteLine(table);
        }
    }
}
