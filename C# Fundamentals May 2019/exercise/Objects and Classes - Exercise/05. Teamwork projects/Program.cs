using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_projects
{
    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < n; i++)
            {
                var newTeam = Console.ReadLine().Split('-').ToArray();
                var membersList = new List<string>();
                Team team = new Team();
                team.TeamName = newTeam[1];
                team.Creator = newTeam[0];
                team.Members = membersList;
                if (!teams.Select(x => x.TeamName).Contains(team.TeamName))
                {
                    if (!teams.Select(x => x.Creator).Contains(team.Creator))
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {newTeam[1]} has been created by {newTeam[0]}!");
                            
                                            }
                    else
                    {
                        Console.WriteLine($"{team.Creator} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {team.TeamName} was already created!");
                }
            }

            var input = Console.ReadLine();

            while (!input.Equals("end of assignment"))
            {
                var split = input.Split(new char[] { '-', '>' }).ToArray();
                var user = split[0];
                var teamName = split[2];
                if (!teams.Select(x => x.TeamName).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Select(x => x.Members).Any(x => x.Contains(user)) || teams.Select(x => x.Creator).Contains(user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    var teamToJoinIndex = teams.FindIndex(x => x.TeamName == teamName);
                    teams[teamToJoinIndex].Members.Add(user);
                }

                input = Console.ReadLine();
            }

            var disband = teams.OrderBy(x => x.TeamName).Where(x => x.Members.Count == 0);
            var teamsToPrint = teams.
            OrderByDescending(x => x.Members.Count).
            ThenBy(x => x.TeamName).
            Where(x => x.Members.Count > 0);

            foreach (var team in teamsToPrint)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var item in disband)
            {
                Console.WriteLine(item.TeamName);
            }

        }
    }
}
