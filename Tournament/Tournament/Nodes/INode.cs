using System;
using Tournament.Team;

namespace Tournament.Nodes
{
    public enum MatchOutcome
    {
        OneVsOneWinner = 1,
        OneVsOneLooser = 2

    }


    public interface INode
    {
        bool IsGameFinnished();
        ITeam GetCompeditor(MatchOutcome position);
        int GetNumberOfCompeditors();
        void Update();
        void AddFinalist(INode node, MatchOutcome pos);
    }
}
