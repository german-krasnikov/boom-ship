using System.Collections.Generic;
using System.Linq;

namespace Code.Metro.Graph
{
    public class Graph
    {
        private readonly List<Node> _nodes;

        public Graph()
        {
            _nodes = new List<Node>();
        }

        public void Add(Node n)
        {
            _nodes.Add(n);
        }

        public void Remove(Node n)
        {
            _nodes.Remove(n);
        }

        public List<Node> GetNodes()
        {
            return _nodes.ToList();
        }

        public int GetCount()
        {
            return _nodes.Count;
        }
    }
}