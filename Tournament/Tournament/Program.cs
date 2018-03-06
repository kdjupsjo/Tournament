using System;
using System.Collections.Generic;
using Tournament.Nodes;
using Tournament.Rule;
using Tournament.Team;
using Tournament.Tournament;

namespace Tournament
{
    class Program
    {
        static void Main(string[] args)
        {

            List<ITeam> teams = GenerateListOfTeam();

            List<LeafNode> nodes = GenerateListOfNodes(teams);

            TestMultiFinalist(nodes);

            SingleElimination tournament = new SingleElimination();

            foreach( LeafNode n in nodes)
            {
                tournament.AddLeafNode(n);
            }

            tournament.GenerateTournamentTree();

            return;
        }

        public static void TestMultiFinalist(List<LeafNode> leafNodesList)
        {
            MatchNode mn = new MatchNode();
            MatchNode final = new MatchNode();

            IRule rule = new BestOf();
            mn.SetRule(rule);
            final.SetRule(rule);

            foreach (LeafNode ln in leafNodesList)
            {
                mn.AddFinalist(ln, MatchOutcome.OneVsOneWinner);
            }

            final.AddFinalist(mn, MatchOutcome.OneVsOneWinner);
            final.AddFinalist(leafNodesList[3], MatchOutcome.OneVsOneWinner);
            mn.Update();
            final.Update();
            mn.GiveTeamOnePoint(leafNodesList[0].GetCompeditor(0));

            ITeam winner = mn.GetCompeditor(MatchOutcome.OneVsOneWinner);
            ITeam loser = mn.GetCompeditor(MatchOutcome.OneVsOneLooser);
            final.Update();

            for (int i = 0; i < 9; i++)
            {
                mn.GiveTeamOnePoint(mn.GetCompeditors()[0]);
            }
            winner = mn.GetCompeditor(MatchOutcome.OneVsOneWinner);
            loser = mn.GetCompeditor(MatchOutcome.OneVsOneLooser);
            final.Update();

            EndNode tournamentFirstPlace = new EndNode();
            EndNode tournamentSecondPlace = new EndNode();
            EndNode tournamentThirdPlace = new EndNode();

            tournamentFirstPlace.AddFinalist(final, MatchOutcome.OneVsOneWinner);
            tournamentSecondPlace.AddFinalist(final, MatchOutcome.OneVsOneLooser);
            tournamentThirdPlace.AddFinalist(mn, MatchOutcome.OneVsOneLooser);

            final.GiveTeamOnePoint(winner);
            final.GiveTeamOnePoint(winner);

            tournamentFirstPlace.Update();
            tournamentSecondPlace.Update();
            tournamentThirdPlace.Update();


            return;
        }


        public static List<ITeam> GenerateListOfTeam()
        { 
            List<ITeam> teams = new List<ITeam>();

            teams.Add(new Competitor("Team Tungk"));
            teams.Add(new Competitor("Team Beast"));
            teams.Add(new Competitor("Team Solid"));
            teams.Add(new Competitor("Team Public"));
            teams.Add(new Competitor("Horde"));
            teams.Add(new Competitor("Virtues Amatures"));

            return teams;

        }

        public static List<LeafNode> GenerateListOfNodes(List<ITeam> teamList)
        {
            List<LeafNode> nodes = new List<LeafNode>();

            foreach (ITeam team in teamList)
            {
                nodes.Add(new LeafNode(team));
            }

            return nodes; 
        }
    }
}
