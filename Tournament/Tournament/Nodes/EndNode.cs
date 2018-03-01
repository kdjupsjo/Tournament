using System;
using Tournament.Team;

namespace Tournament.Nodes
{
    public class EndNode :INode
    {
        public EndNode()
        {
        }

        public ITeam GetCompeditor(int position)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfCompeditors()
        {
            throw new NotImplementedException();
        }

        public bool IsGameFinnished()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
