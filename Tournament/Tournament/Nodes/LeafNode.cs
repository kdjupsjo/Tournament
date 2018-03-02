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

        public void AddFinalist(INode node, MatchOutcome pos)
        {
            
        }

        public ITeam GetCompeditor(MatchOutcome position)
        {
            return LeafNodeTeam;
        }

        public int GetNodeDepth()
        {
            return 0;
        }

        public int GetNumberOfCompeditors()
        {
            return 1;
        }

        public bool IsGameActive()
        {
            return false;
        }

        public bool IsGameFinished()
        {
            return true;
        }

        public void Update()
        {
            
        }
    }
}
