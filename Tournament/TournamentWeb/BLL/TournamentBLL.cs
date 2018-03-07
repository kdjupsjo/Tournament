using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournament.Nodes;
using Tournament.Team;
using TournamentWeb.DAL;

namespace TournamentWeb.BLL
{
    public class TournamentBLL
    {
        private TournamentMockUp conn; 

        public TournamentBLL()
        {
            conn = TournamentMockUp.Instance();
        }


        public void AddLeafNode(string team)
        {
            var tempTeam = new Competitor(team);

            var leafnode = new LeafNode(tempTeam);

            conn.AddCompetitor(leafnode);

        }


    }
}