﻿using System;
using System.Collections.Generic;
using Tournament.Nodes;
using Tournament.Rule;

namespace Tournament.Tournament
{
    public class SingleElimination : ITournament
    {
        List<LeafNode> SingleEliminationTeamEntryPoints;
        MatchNode SingleEliminationFinal;
        MatchNode SingleEliminationThirdPlaceFinal;
        List<EndNode> SingleEliminationPlacements;
        IRule SingleEliminationGameRule;

        public SingleElimination()
        {

            SingleEliminationGameRule = new BestOf(3);
            SingleEliminationTeamEntryPoints = new List<LeafNode>();
            SingleEliminationFinal = GenerateMatchNode();
            SingleEliminationPlacements = new List<EndNode>();

        }
        public void AddLeafNode(LeafNode node)
        {
            SingleEliminationTeamEntryPoints.Add(node);
        }
        public void SetRulesForGames(IRule rule)
        {
            SingleEliminationGameRule = rule;
        }
        public void GenerateTournamentTree()
        {
            SingleEliminationFinal = GenerateMatchNode();
            SingleEliminationThirdPlaceFinal = GenerateMatchNode();

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
                EndNode FourthPlace = new EndNode();

                List<FinalistData> finalistData = SingleEliminationFinal.GetFinalists();

                if (finalistData.Count > 1)
                {
                    MatchNode thirdPlaceFianl = GenerateMatchNode();
                    thirdPlaceFianl.AddFinalist(
                        finalistData[0].GetNode(),
                        MatchOutcome.OneVsOneLooser);
                    thirdPlaceFianl.AddFinalist(
                        finalistData[1].GetNode(),
                        MatchOutcome.OneVsOneLooser);

                    ThirdPlace.AddFinalist(thirdPlaceFianl, MatchOutcome.OneVsOneWinner);
                    FourthPlace.AddFinalist(thirdPlaceFianl, MatchOutcome.OneVsOneLooser);
                    SingleEliminationPlacements.Add(ThirdPlace);
                    SingleEliminationPlacements.Add(FourthPlace);
                }
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

                MatchNode newMatch = GenerateMatchNode();
                newMatch.AddFinalist(first);
                newMatch.AddFinalist(second);

                SingleEliminationFinal.AddFinalist(newMatch, MatchOutcome.OneVsOneWinner);


                canMerge = CanMerge();
            }

            return canMerge;
        }
        private MatchNode GenerateMatchNode()
        {
            return new MatchNode(SingleEliminationGameRule);
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

        public List<LeafNode> GetTournamentLeafNodes()
        {
            return SingleEliminationTeamEntryPoints;
        }
    }
}
