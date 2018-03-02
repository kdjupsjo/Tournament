using System;
using Tournament.Team;

namespace Tournament.Nodes
{
    public class FinalistData
    {
        private INode FinalistDataNode;
        private MatchOutcome FinalistDataPosition;

        public FinalistData()
        {
            FinalistDataNode = null;
            FinalistDataPosition = MatchOutcome.OneVsOneWinner;
        }

        public FinalistData(INode node, MatchOutcome position)
        {
            SetFinilist(node, position);
        }

        public void SetFinilist(INode node, MatchOutcome position)
        {
            FinalistDataNode = node;
            FinalistDataPosition = position;
        }

        public INode GetNode()
        {
            return FinalistDataNode;
        }

        public MatchOutcome GetPosition()
        {
            return FinalistDataPosition;
        }

        public ITeam GetCompeditor()
        {
            ITeam team = FinalistDataNode.GetCompeditor(FinalistDataPosition);

            return team;
        }
    }

}
