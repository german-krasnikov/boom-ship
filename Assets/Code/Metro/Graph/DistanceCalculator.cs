using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Metro.Graph
{
    public class DistanceCalculator
    {
        private Dictionary<Node, int> _distances;
        private Dictionary<Node, Node> _routes;
        private Graph _graph;
        private List<Node> _allNodes;

        public DistanceCalculator(Graph graph)
        {
            _graph = graph;
            _allNodes = graph.GetNodes();
            _distances = SetDistances();
            _routes = SetRoutes();
        }

        private Dictionary<Node, int> SetDistances()
        {
            Dictionary<Node, int> distances = new Dictionary<Node, int>();

            foreach (Node n in _graph.GetNodes())
                distances.Add(n, int.MaxValue);
            return distances;
        }

        private Dictionary<Node, Node> SetRoutes()
        {
            Dictionary<Node, Node> routes = new Dictionary<Node, Node>();

            foreach (Node n in _graph.GetNodes())
                routes.Add(n, null);
            return routes;
        }

        public void Calculate(Node source, Node destination)
        {
            _distances[source] = 0;

            while (_allNodes.ToList().Count != 0)
            {
                Node leastExpensiveNode = GetLeastExpensiveNode();
                ExamineConnections(leastExpensiveNode);
                _allNodes.Remove(leastExpensiveNode);
            }
            Print(source, destination);
        }

        private void ExamineConnections(Node n)
        {
            foreach (var neighbor in n.GetNeighbors())
            {
                if (_distances[n] + neighbor.Value < _distances[neighbor.Key])
                {
                    _distances[neighbor.Key] = neighbor.Value + _distances[n];
                    _routes[neighbor.Key] = n;
                }
            }
        }

        private Node GetLeastExpensiveNode()
        {
            Node leastExpensive = _allNodes.FirstOrDefault();

            foreach (var n in _allNodes)
            {
                if (_distances[n] < _distances[leastExpensive])
                    leastExpensive = n;
            }

            return leastExpensive;
        }

        private void Print(Node source, Node destination)
        {
            Debug.Log($"Distance from {source.GetName()} to {destination.GetName()} is: {_distances[destination]}");
            PrintLeg(destination);
        }

        private void PrintLeg(Node d)
        {
            if (_routes[d] == null)
                return;
            Debug.Log($"{d.GetName()} <-- {_routes[d].GetName()}");
            PrintLeg(_routes[d]);
        }
    }
}