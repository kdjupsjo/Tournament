using System;
using System.Collections.Generic;
using Tournament.Team;

namespace Tournament.Nodes
{
    public class MatchNode : INode
    {
        List<ITeam> MatchNodeCompeditors;
        List<FinalistData> MatchNodeFinalists;

        public MatchNode()
        {
            MatchNodeCompeditors = new List<ITeam>();
            MatchNodeFinalists = new List<FinalistData>();
        }

        public ITeam GetCompeditor(int position)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfCompeditors()
        {
            return MatchNodeCompeditors.Count;
        }

        public bool IsGameFinnished()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            for (int i = 0; i < MatchNodeFinalists.Count; i++)
            {
                FinalistData finalist = MatchNodeFinalists[i];
                INode node = finalist.GetNode();
                int position = finalist.GetPosition();

                ITeam compeditor = node.GetCompeditor(position);

                if (compeditor.Equals(DummyTeamCreator.DummyTeamInstance))
                {

                }
                else
                {
                    MatchNodeCompeditors.Add(compeditor);
                    MatchNodeFinalists.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
