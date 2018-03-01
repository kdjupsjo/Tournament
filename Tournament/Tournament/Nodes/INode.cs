using System;
using Tournament.Team;

namespace Tournament.Nodes
{
    public interface INode
    {
        bool IsGameFinnished();
        ITeam GetCompeditor(int position);
        int GetNumberOfCompeditors();
        void Update();
    }
}
