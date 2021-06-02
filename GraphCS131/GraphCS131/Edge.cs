using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCS131
{
    class Edge<T>
    {
        public Vertex<T> Start { get; set; }
        public Vertex<T> End { get; set; }
        public double Weight { get; set; }

        public Edge(Vertex<T> start, Vertex<T> end, double weight)
        {
            Start = start;
            End = end;
            Weight = weight;
        }


    }
}
