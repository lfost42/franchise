using System;
using System.Collections.Generic;

namespace ParserLibrary.Models
{
    public class NodeModel
    {
        private readonly int VertexId;
        private readonly HashSet<int> AdjacencySet;

        public NodeModel(int vertexId)
        {
            this.VertexId = vertexId;
            this.AdjacencySet = new HashSet<int>();
        }

        public void AddEdge(int v)
        {
            if (this.VertexId == v)
                throw new ArgumentException("Vertex cannot be adjacent to itself");
            this.AdjacencySet.Add(v);
        }

        public HashSet<int> GetAdjacentVertices()
        {
            return this.AdjacencySet;
        }

    }
}
