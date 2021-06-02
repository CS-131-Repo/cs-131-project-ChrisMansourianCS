using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GraphCS131
{
    class Graph<T>
    {
        List<Vertex<T>> vertices = new List<Vertex<T>>();

        public IReadOnlyList<Vertex<T>> Vertices { get { return vertices; } }

        public IReadOnlyList<Edge<T>> Edges
        {
            get
            {
                HashSet<Edge<T>> edges = new HashSet<Edge<T>>();
                foreach (var vertex in vertices)
                {
                    foreach (var edge in vertex.Neighbors)
                    {
                        edges.Add(edge);
                    }
                }
                return edges.ToList();
            }
        }

        /// <summary>
        /// Adds a vertex with the value to the graph
        /// </summary>
        /// <param name="val">The value to add</param>
        /// <returns>True if it inserted, false if not</returns>
        public bool AddVertex(T val)
        {
            if (Search(val) != null)
            {
                return false;
            }

            vertices.Add(new Vertex<T>(val));

            return true;
        }

        /// <summary>
        /// Adds an edge between two vertices
        /// </summary>
        /// <param name="val1">The first value vertex to add</param>
        /// <param name="val2">The second value vertex to add</param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public bool AddEdge(T val1, T val2, double weight)
        {
            return AddEdge(Search(val1), Search(val2), weight);
        }

        /// <summary>
        /// Adds edge between vertices
        /// </summary>
        /// <param name="v1">First vertex</param>
        /// <param name="v2">Second vertex</param>
        /// <param name="weight">Weight of the edge</param>
        /// <returns>True if it added.  False if a vertex was null or edge exists</returns>
        private bool AddEdge(Vertex<T> v1, Vertex<T> v2, double weight)
        {
            if (v1 == null || v2 == null || FindEdge(v1, v2) != null)
            {
                return false;
            }

            Edge<T> edge = new Edge<T>(v1, v2, weight);
            v1.Neighbors.Add(edge);
            v2.Neighbors.Add(edge);

            return true;
        }

        /// <summary>
        /// Removes edge between two vertices
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public bool RemoveEdge(T val1, T val2)
        {
            return RemoveEdge(Search(val1), Search(val2));
        }

        private bool RemoveEdge(Vertex<T> v1, Vertex<T> v2)
        {
            Edge<T> edge = FindEdge(v1, v2);
            if (v1 == null || v2 == null || edge == null)
            {
                return false;
            }

            v1.Neighbors.Remove(edge);
            v2.Neighbors.Remove(edge);

            return true;
        }

        /// <summary>
        /// Searches for a given value in the graph
        /// </summary>
        /// <param name="val">The value to search for</param>
        /// <returns>The Vertex that has the matching value</returns>
        public Vertex<T> Search(T val)
        {
            foreach (var item in vertices)
            {
                if (item.Value.Equals(val))
                {
                    return item;
                }
            }
            return null;
        }

        private Edge<T> FindEdge(Vertex<T> v1, Vertex<T> v2)
        {
            foreach (var edge in v1.Neighbors)
            {
                if (edge.Start == v1 && edge.End == v2)
                {
                    return edge;
                }
            }
            return null;
        }

        /// <summary>
        /// Takes in two values and finds the path to get from the start one to the end
        /// </summary>
        /// <param name="s">The start value</param>
        /// <param name="e">The end value</param>
        /// <returns>The list of all possible paths from start to the end</returns>
        public List<List<Vertex<T>>> FindAllPaths(T s, T e)
        {
            Vertex<T> start = Search(s);
            Vertex<T> end = Search(e);
            if (end == null || start == null) { return null; }

            foreach (var vertex in vertices)
            {
                vertex.IsVisited = false;
            }
            List<List<Vertex<T>>> paths = new List<List<Vertex<T>>>();
            FindAllPaths(start, end, new List<Vertex<T>>(), paths);
            return paths;
        }

        private void FindAllPaths(Vertex<T> current, Vertex<T> end, List<Vertex<T>> founders, List<List<Vertex<T>>> paths)
        {
            if(current == end)
            {
                founders.Add(current);
                paths.Add(founders.ToList());
                founders.Remove(current);
                return;
            }
            if (current.IsVisited)
            {
                return;
            }
            current.IsVisited = true;
            founders.Add(current);
            foreach(var vertex in current.Neighbors)
            {
                if (vertex.Start == current)
                {
                    FindAllPaths(vertex.End, end, founders, paths);
                }
            }
            founders.Remove(current);
            current.IsVisited = false;
        }
    }
}
