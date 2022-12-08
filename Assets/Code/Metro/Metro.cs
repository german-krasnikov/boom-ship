using System;
using System.Collections.Generic;
using System.Linq;
using Code.Metro.Graph;
using UnityEngine;
using static Code.PathFind.MetroHelper;
using Random = UnityEngine.Random;

namespace Code.PathFind
{
    public class Metro
    {
        public readonly string[] STATION_NAMES = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "O" };
        private readonly Color[] SUBWAY_COLORS = { Color.black, Color.red, Color.green, Color.blue };

        private Graph _metro;
        private Dictionary<Color, SubwayLine> _subways;
        private Dictionary<string, Node> _stations;

        public void Initialize()
        {
            _metro = new Graph();

            _subways = InitSubways(SUBWAY_COLORS);
            _stations = InitStations(STATION_NAMES);
            AddStationsToMetro();

            LinkStationsToSubways(_stations, _subways);
            LinkStationsToNeighbours();
        }

        private void AddStationsToMetro()
        {
            foreach (var station in _stations.Values)
                _metro.Add(station);
        }

        public void Calculate(string from, string to)
        {
            DistanceCalculator calculator = new DistanceCalculator(_metro);
            calculator.Calculate(_stations[from], _stations[to]);
        }

        public Tuple<string, string> GetTwoRandomStationNames()
        {
            var names = STATION_NAMES.ToList();
            var randomIndex = Random.Range(0, names.Count);
            var first = names[randomIndex];
            names.RemoveAt(randomIndex);
            randomIndex = Random.Range(0, names.Count);
            return new Tuple<string, string>(first, names[randomIndex]);
        }

        private void LinkStationsToSubways(Dictionary<string, Node> stations, Dictionary<Color, SubwayLine> subways)
        {
            AddStationToSubways(stations["A"], subways.GetSubwaysByColors(new[] { Color.red }));
            AddStationToSubways(stations["B"], subways.GetSubwaysByColors(new[] { Color.red, Color.black }));
            AddStationToSubways(stations["C"], subways.GetSubwaysByColors(new[] { Color.red, Color.green }));
            AddStationToSubways(stations["D"], subways.GetSubwaysByColors(new[] { Color.red, Color.blue }));
            AddStationToSubways(stations["E"], subways.GetSubwaysByColors(new[] { Color.red, Color.green }));
            AddStationToSubways(stations["F"], subways.GetSubwaysByColors(new[] { Color.red, Color.black }));
            AddStationToSubways(stations["G"], subways.GetSubwaysByColors(new[] { Color.black }));
            AddStationToSubways(stations["H"], subways.GetSubwaysByColors(new[] { Color.black }));
            AddStationToSubways(stations["J"], subways.GetSubwaysByColors(new[] { Color.black, Color.blue, Color.green }));
            AddStationToSubways(stations["K"], subways.GetSubwaysByColors(new[] { Color.green }));
            AddStationToSubways(stations["L"], subways.GetSubwaysByColors(new[] { Color.green, Color.blue }));
            AddStationToSubways(stations["M"], subways.GetSubwaysByColors(new[] { Color.green }));
            AddStationToSubways(stations["N"], subways.GetSubwaysByColors(new[] { Color.blue }));
            AddStationToSubways(stations["O"], subways.GetSubwaysByColors(new[] { Color.blue }));
        }

        private void LinkStationsToNeighbours()
        {
            AddNeighboursToStation(_stations["A"], _stations.GetStationsByName(new[] { "B" }));
            AddNeighboursToStation(_stations["B"], _stations.GetStationsByName(new[] { "A", "H", "C" }));
            AddNeighboursToStation(_stations["C"], _stations.GetStationsByName(new[] { "B", "J", "D", "K" }));
            AddNeighboursToStation(_stations["D"], _stations.GetStationsByName(new[] { "C", "J", "E", "M", "L" }));
            AddNeighboursToStation(_stations["E"], _stations.GetStationsByName(new[] { "D", "J", "F", "M" }));
            AddNeighboursToStation(_stations["F"], _stations.GetStationsByName(new[] { "E", "J", "G" }));
            AddNeighboursToStation(_stations["G"], _stations.GetStationsByName(new[] { "F" }));
            AddNeighboursToStation(_stations["H"], _stations.GetStationsByName(new[] { "B", "J" }));
            AddNeighboursToStation(_stations["J"], _stations.GetStationsByName(new[] { "H", "O", "F", "E", "D", "C" }));
            AddNeighboursToStation(_stations["K"], _stations.GetStationsByName(new[] { "C", "L" }));
            AddNeighboursToStation(_stations["L"], _stations.GetStationsByName(new[] { "K", "D", "M", "N" }));
            AddNeighboursToStation(_stations["M"], _stations.GetStationsByName(new[] { "L", "E" }));
            AddNeighboursToStation(_stations["N"], _stations.GetStationsByName(new[] { "L" }));
            AddNeighboursToStation(_stations["O"], _stations.GetStationsByName(new[] { "J" }));
        }
    }
}