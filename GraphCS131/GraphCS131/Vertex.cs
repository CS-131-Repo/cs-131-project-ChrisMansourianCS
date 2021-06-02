using System;
using System.Collections.Generic;
using System.Text;

namespace GraphCS131
{
    class Vertex<T>
    {
        public T Value { get; set; }

        public bool IsVisited { get; set; } = false;

        public List<Edge<T>> Neighbors { get; set; } = new List<Edge<T>>();

        public Vertex(T Value)
        {
            this.Value = Value;
        }
    }
}
