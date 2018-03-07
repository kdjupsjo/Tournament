using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournament.Tournament;
using Tournament.Rule;
using Tournament.Nodes;

namespace TournamentWeb.DAL
{
    public class TournamentMockUp
    {
        private SingleElimination tournament;
        private static TournamentMockUp instance;

        private TournamentMockUp()
        {
            var rule = new BestOf(3);

            tournament = new SingleElimination();
            tournament.SetRulesForGames(rule);
        }

        public static TournamentMockUp Instance() {
            if (instance == null )
            {
                instance = new TournamentMockUp();
            }

            return instance; 
        }



        public void AddCompetitor(LeafNode team)
        {
            //TODO Validate if team existS??

            tournament.AddLeafNode(team);
        }


    }
}