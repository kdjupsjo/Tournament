using System;
using System.Collections.Generic;
using System.Text;
using Tournament.Nodes;
using Tournament.Team;

namespace Tournament.Rule
{
    public class DummyRule : IRule
    {
        public bool CanGameRun(INode game)
        {
            return true;
        }

        public ITeam GetCompetitorPosition(INode game, int pos)
        {
            return DummyTeamCreator.DummyTeamInstance;
        }

        public bool IsGameFull(INode game)
        {
            return true;
        }

        public bool IsGameOver(INode game)
        {
            return true; 
        }


    }

    public static class DummyRuleCreator
    {
        public static DummyRule DummyRuleInstance = new DummyRule();
    }
}
