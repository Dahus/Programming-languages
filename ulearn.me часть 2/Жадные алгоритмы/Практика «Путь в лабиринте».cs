// Вставьте сюда финальное содержимое файла DijkstraPathFinder.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greedy.Architecture;
using System.Drawing;

namespace Greedy
{
    public class DijkstraData
    {
        public Point Previous { get; set; }
        public int Price { get; set; }
    }

    public class DijkstraPathFinder
    {
        public IEnumerable<PathWithCost> GetPathsByDijkstra(State state, Point start,
            IEnumerable<Point> targets)
        {
            foreach (var path in GetPaths(start, state, targets.ToList()))
            {
                yield return path;
            }
        }

        public IEnumerable<PathWithCost> GetPaths(Point start, State state, List<Point> targets)
        {
            var foundChests = new List<Point>(targets);
            var notVisited = new List<Point>(GetEdges(start, state));
            var visited = new List<Point>();
            notVisited.Add(start);
            var track = new Dictionary<Point, DijkstraData>
            {
                [start] = new DijkstraData { Price = 0, Previous = new Point(int.MinValue, int.MinValue) }
            };

            while (!notVisited.Count.Equals(0))
            {
                var toOpen = new Point(int.MinValue, int.MinValue);
                var bestPrice = double.PositiveInfinity;
                foreach (var e in notVisited)
                {
                    if (track.ContainsKey(e) && track[e].Price < bestPrice)
                    {
                        bestPrice = track[e].Price;
                        toOpen = e;
                    }
                }

                DoPoints(state, toOpen, track, notVisited, visited);                

                if (foundChests.Contains(toOpen))
                {
                    foundChests.Remove(toOpen);
                    yield return GetPathWithCost(track, toOpen);
                }  
            }
        }

        public void DoPoints(State state, Point toOpen, Dictionary<Point, DijkstraData> track, 
            List<Point> notVisited, List<Point> visited)
        {
            foreach (var e in GetEdges(toOpen, state))
            {
                 var currentPrice = track[toOpen].Price + state.CellCost[e.X, e.Y];
                 if (!visited.Contains(e))
                     notVisited.Add(e);
                 if (!track.ContainsKey(e) || track[e].Price > currentPrice)
                 {
                     track.Add(e, new DijkstraData { Previous = toOpen, Price = currentPrice });
                 }
                 visited.Add(e);
            }

            visited.Add(toOpen);
            notVisited.Remove(toOpen);
        }

        public PathWithCost GetPathWithCost(Dictionary<Point, DijkstraData> track, Point toOpen)
        {
            var path = new List<Point>();
            var end = toOpen;
            while (end != new Point(int.MinValue, int.MinValue))
            {
                path.Add(end);
                end = track[end].Previous;
            }
            path.Reverse();
            return new PathWithCost(track[toOpen].Price, path.ToArray());
        }

        public IEnumerable<Point> GetEdges(Point toOpen, State state)
        {
            var edges = new List<Size>
            {
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0),
                new Size(0, -1)
            };

            foreach (var e in edges)
            {
                var next = toOpen + e;
                if (state.InsideMap(next) && state.CellCost[next.X, next.Y] != 0)
                {
                    yield return next;
                }
            }
        }
    }
}