using System;
using Tournament.Nodes;
using System.Collections.Generic;
using Tournament.Rule;

namespace Tournament.Tournament
{
    public interface ITournament
    {
        void AddLeafNode(LeafNode node);
        List<LeafNode> GetTournamentLeafNodes();
        void GenerateTournamentTree();
        List<INode> GetActiveTournamnetNodes();
        void SetRulesForGames(IRule rule);
    }
}