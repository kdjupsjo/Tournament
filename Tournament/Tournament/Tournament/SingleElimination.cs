using System;
using System.Collections.Generic;
using Tournament.Nodes;

namespace Tournament.Tournament
{
    public class SingleElimination : ITournament
    {
        List<LeafNode> SingleEliminationTeamEntryPoints;
        List<MatchNode> SingleEliminationMatches;
        List<EndNode> SingleEliminationPlacements;

        public SingleElimination()
        {
            SingleEliminationTeamEntryPoints = new List<LeafNode>();
            SingleEliminationMatches = new List<MatchNode>();
            SingleEliminationPlacements = new List<EndNode>();
        }

        public void AddLeafNode(LeafNode node)
        {
            SingleEliminationTeamEntryPoints.Add(node);
        }

        public void GenerateTournamentTree()
        {
            throw new NotImplementedException();
        }

        public List<INode> GetActiveTournamnetNodes()
        {
            List<INode> activeNodes = new List<INode>();

            foreach(INode match in SingleEliminationMatches)
            {
                if ( match.IsGameActive() )
                {
                    activeNodes.Add(match);
                }
            }

            return activeNodes;
        }
    }
}
