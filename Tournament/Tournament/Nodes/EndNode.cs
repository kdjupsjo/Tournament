using System;
using Tournament.Team;

namespace Tournament.Nodes
{
    public class EndNode :INode
    {
        private ITeam EndNodeTeam;
        private FinalistData EndNodeFinalist;

        public EndNode()
        {
            EndNodeTeam = DummyTeamCreator.DummyTeamInstance;
        }

        public void AddFinalist(INode node, MatchOutcome pos)
        {
            EndNodeFinalist = new FinalistData(node, pos);
        }

        public ITeam GetCompeditor(MatchOutcome position)
        {
            return EndNodeTeam;
        }

        public int GetNumberOfCompeditors()
        {
            return 1;
        }

        public bool IsGameFinnished()
        {
            return EndNodeTeam != DummyTeamCreator.DummyTeamInstance;
        }

        public void Update()
        {
            if ( !IsGameFinnished() )
            {
                ITeam team = EndNodeFinalist.GetCompeditor();

                if ( team != DummyTeamCreator.DummyTeamInstance )
                {
                    EndNodeTeam = team;

                }
            }
        }
    }
}
