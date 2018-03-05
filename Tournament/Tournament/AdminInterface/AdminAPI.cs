using System;
using System.Collections.Generic;
using Tournament.Rule;
using Tournament.Nodes;
using Tournament.Tournament;

namespace Tournament.AdminInterface
{
    public class AdminAPI
    {
        private ITournament activeTournamnet;

        public AdminAPI()
        {

        }

        public void AddTournamnet(String name)
        {
            activeTournamnet = new SingleElimination();
        }

        public void AddTeamToTournamnent(LeafNode team)
        {
            if ( activeTournamnet != null )
            {
                activeTournamnet.AddLeafNode(team);
            }
        }

        public void GenerateTournamnet()
        {
            if (activeTournamnet != null)
            {
                activeTournamnet.GenerateTournamentTree();
            }

        }


        public void GetTeams()
        {
            if ( activeTournamnet != null )
            {
                List<LeafNode> teams = activeTournamnet.GetTournamentLeafNodes();
            }
        }

        public void NumberOfgames( int games )
        {
            if ( activeTournamnet != null)
            {
                IRule rule = new BestOf(games);
                activeTournamnet.SetRulesForGames(rule);
            }
        }

    }
}
