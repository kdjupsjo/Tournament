using System;
using Tournament.Nodes;
using Tournament.Team;

namespace Tournament.Rule
{
    public interface IRule
    {
        bool CanGameRun(INode game);
        bool IsGameOver(INode game);
        ITeam GetCompetitorPosition(INode game, int pos);
        bool IsGameFull(INode game); 
    }
}
