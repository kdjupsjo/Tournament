using System;
using Tournament.Nodes;

namespace Tournament.Rule
{
    public class BestOf : IRule
    {
        
        public BestOf()
        {
        }

        public bool CanGameRun(INode game)
        {
            int compeditors = game.GetNumberOfCompeditors();


            return false;
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public void SortCompeditors()
        {
            throw new NotImplementedException();
        }
    }
}
