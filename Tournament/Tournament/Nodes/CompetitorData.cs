using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Team;

namespace Tournament.Nodes
{
    public class CompetitorData
    {
        private ITeam CompetitorTeam;
        private int CompetitorScore;

        public CompetitorData(ITeam competitorTeam) {
            CompetitorTeam = competitorTeam;
            CompetitorScore = 0;
        }

        public int GetScore()
        {
            return CompetitorScore;
        }

        public void IncrementScore()
        {
            CompetitorScore++;
        }

        public ITeam GetTeam()
        {
            return CompetitorTeam;
        }
        public void SetTeam(ITeam team)
        {
            CompetitorTeam = team;
        }
    }
}
