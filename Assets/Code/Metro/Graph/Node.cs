using System.Collections.Generic;

namespace Code.Metro.Graph
{
    public class Node
    {
        private string _name;
        private List<SubwayLine> _subwayLines;
        private Dictionary<Node, int> _neighbors;

        public Node(string nodeName)
        {
            _name = nodeName;
            _subwayLines = new List<SubwayLine>();
            _neighbors = new Dictionary<Node, int>();
        }

        public void AddNeighbour(Node node, int cost)
        {
            _neighbors.Add(node, cost);
        }

        public void AddSubwayLine(SubwayLine subwayLine)
        {
            _subwayLines.Add(subwayLine);
        }

        public string GetName()
        {
            return _name;
        }

        public Dictionary<Node, int> GetNeighbors()
        {
            return _neighbors;
        }
    }
}