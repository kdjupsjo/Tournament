using System;
namespace Tournament.Team
{
    public class Competitor : ITeam
    {
        private String CompetitorName;

        public Competitor()
        {
            CompetitorName = "Team";
        }

        public Competitor(string competitorName )
        {
            CompetitorName = competitorName;
        }

        public string GetTeamName()
        {
            return CompetitorName;
        }
    }
}
