using System;
using Tournament.Nodes;
using System.Collections.Generic;

namespace Tournament.Tournament
{
    public interface ITournament
    {
        void AddLeafNode(LeafNode node);
        void GenerateTournamentTree();
        List<INode> GetActiveTournamnetNodes();

    }
}