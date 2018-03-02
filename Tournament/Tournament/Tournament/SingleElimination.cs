using System;
using System.Collections.Generic;
using Tournament.Nodes;

namespace Tournament.Tournament
{
    public class SingleElimination : ITournament
    {
        List<LeafNode> SingleEliminationTeamEntryPoints;
        MatchNode SingleEliminationFinal;
        MatchNode SingleEliminationThirdPlaceFinal;
        List<EndNode> SingleEliminationPlacements;

        public SingleElimination()
        {
            SingleEliminationTeamEntryPoints = new List<LeafNode>();
            SingleEliminationFinal = new MatchNode();
            SingleEliminationPlacements = new List<EndNode>();
        }

        public void AddLeafNode(LeafNode node)
        {
            SingleEliminationTeamEntryPoints.Add(node);
        }

        public void GenerateTournamentTree()
        {
            SingleEliminationFinal = new MatchNode();
            SingleEliminationThirdPlaceFinal = new MatchNode();

            ConnectLeafNodesToMatch(SingleEliminationFinal);

            while (DoMerge()) { }

            if (SingleEliminationTeamEntryPoints.Count >= 2)
            {
                EndNode firstPlace = new EndNode();
                EndNode SecondPlace = new EndNode();


                firstPlace.AddFinalist(SingleEliminationFinal, MatchOutcome.OneVsOneWinner);
                SecondPlace.AddFinalist(SingleEliminationFinal, MatchOutcome.OneVsOneLooser);
                SingleEliminationPlacements.Add(firstPlace);
                SingleEliminationPlacements.Add(SecondPlace);
            }
            if (SingleEliminationTeamEntryPoints.Count >= 4)
            {
                EndNode ThirdPlace = new EndNode();
                //TODO Get 
            }




        }


        public List<INode> GetActiveTournamnetNodes()
        {
            List<INode> activeNodes = new List<INode>();

            foreach (FinalistData fd in SingleEliminationFinal.GetFinalists())
            {
                INode match = fd.GetNode();

                if (match.IsGameActive())
                {
                    activeNodes.Add(match);
                }
            }

            return activeNodes;
        }
        private bool CanMerge()
        {
            return SingleEliminationFinal.NumberOfFinalists() > 2;
        }
        private bool DoMerge()
        {
            bool canMerge = CanMerge();

            if (canMerge)
            {
                

                FinalistData first = GetShallowNode();
                SingleEliminationFinal.RemoveFinalist(first);

                FinalistData second = GetShallowNode();
                SingleEliminationFinal.RemoveFinalist(second);

                MatchNode newMatch = new MatchNode();
                newMatch.AddFinalist(first);
                newMatch.AddFinalist(second);

                SingleEliminationFinal.AddFinalist(newMatch, MatchOutcome.OneVsOneWinner);


                canMerge = CanMerge();
            }

            return canMerge;
        }

        private FinalistData GetShallowNode()
        {
            FinalistData node = null;

            int shallowest = int.MaxValue;

            foreach ( FinalistData fn in SingleEliminationFinal.GetFinalists())
            {
                INode n = fn.GetNode();
                int depth = n.GetNodeDepth();
                if ( shallowest > depth)
                {
                    shallowest = depth;
                    node = fn;
                }
            }

            return node;
        }

        private void ConnectLeafNodesToMatch(INode game)
        {
            foreach (INode leaf in SingleEliminationTeamEntryPoints)
            {
                game.AddFinalist(leaf, MatchOutcome.OneVsOneWinner);
            }
        }
    }
}
