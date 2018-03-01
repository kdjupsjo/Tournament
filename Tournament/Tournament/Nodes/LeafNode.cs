using System;
using Tournament.Team;

namespace Tournament.Nodes
{
    public class LeafNode : INode
    {
        ITeam LeafNodeTeam;

        public LeafNode()
        {
            LeafNodeTeam = DummyTeamCreator.DummyTeamInstance;
        }

        public LeafNode(ITeam team)
        {
            LeafNodeTeam = team;
        }

        public ITeam GetCompeditor(MatchOutcome position)
        {
            return LeafNodeTeam;
        }

        public int GetNumberOfCompeditors()
        {
            throw new NotImplementedException();
        }

        public bool IsGameFinnished()
        {
            return true;
        }

        public void Update()
        {
            
        }
    }
}
