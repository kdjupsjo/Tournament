using System;
namespace Tournament.Nodes
{
    public class FinalistData
    {
        private INode FinalistDataNode;
        private int FinalistDataPosition;

        public FinalistData()
        {
            FinalistDataNode = null;
            FinalistDataPosition = -1;
        }

        public FinalistData( INode node, int position )
        {
            SetFinilist(node, position);
        }

        public void SetFinilist( INode node, int position )
        {
            FinalistDataNode = node;
            FinalistDataPosition = position;
        }

        public INode GetNode()
        {
            return FinalistDataNode;
        }

        public int GetPosition()
        {
            return FinalistDataPosition;
        }
    }
}
