using System.Collections.Generic;
using Code.Metro.Graph;
using UnityEngine;

namespace Code.PathFind
{
    public static class MetroHelper
    {
        public static List<SubwayLine> GetSubwaysByColors(this Dictionary<Color, SubwayLine> subways, Color[] colors)
        {
            var result = new List<SubwayLine>();
            foreach (var color in colors)
            {
                var subway = GetSubwayLineByColor(subways, color);
                if (subway != null)
                    result.Add(subway);
            }
            return result;
        }

        public static Dictionary<string, Node> InitStations(string[] names)
        {
            var result = new Dictionary<string, Node>();
            foreach (var name in names)
                result[name] = new Node(name);
            return result;
        }

        public static Dictionary<Color, SubwayLine> InitSubways(Color[] colors)
        {
            var result = new Dictionary<Color, SubwayLine>();
            foreach (var color in colors)
                result[color] = new SubwayLine(color);
            return result;
        }

        public static void AddStationToSubways(Node station, List<SubwayLine> subways)
        {
            foreach (var subway in subways)
                station.AddSubwayLine(subway);
        }

        public static List<Node> GetStationsByName(this Dictionary<string, Node> stations, string[] names)
        {
            var result = new List<Node>();
            foreach (var name in names)
                result.Add(stations[name]);
            return result;
        }

        private static SubwayLine GetSubwayLineByColor(Dictionary<Color, SubwayLine> subways, Color color)
        {
            return subways.ContainsKey(color) ? subways[color] : null;
        }

        public static void AddNeighboursToStation(Node station, List<Node> neighbours)
        {
            foreach (var neighbour in neighbours)
                station.AddNeighbour(neighbour, 1);
        }
    }
}