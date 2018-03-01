using System;
using Tournament.Nodes;

namespace Tournament.Rule
{
    public interface IRule
    {
        bool CanGameRun(INode game);
        bool IsGameOver();
        void SortCompeditors();

    }
}
