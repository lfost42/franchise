using System;
using System.Collections.Generic;
using System.Linq;
using Franchise.Data.Models;

namespace Franchise.Data.Databases
{
    public class GraphControl
    {


        static List<EdgeModel> Kruskals_MST(List<EdgeModel> edges, List<int> vertices)
        {
            List<EdgeModel> result = new List<EdgeModel>();

            SetModel set = new SetModel(237/*numlocations*/);

            foreach (int vertex in vertices)
                set.MakeSet(vertex);

            var sortedEdge = edges.OrderBy(x => x.Weight).ToList();

            foreach (EdgeModel edge in sortedEdge)
            {
                if (set.FindSet(edge.Vertex1) != set.FindSet(edge.Vertex2))
                {
                    result.Add(edge);
                    set.Union(edge.Vertex1, edge.Vertex2);
                }
            }
            return result;
        }

        public void PrintResults() //Implement function
        {
            List<EdgeModel> edges = new List<EdgeModel>();

            // need a method that builds each vertex to load into this list
            // see DistanceControl
            //edges.Add(new EdgeModel()
            //{
            //    Vertex1 = 1,
            //    Vertex2 = 3,
            //    Weight = 5
            //});

            //set of vertices
            List<int> vertices = new List<int>()
            {
                0, 1, 2, 3, 4 /* ... 237 list vertices */
            };

            List<EdgeModel> MST = Kruskals_MST(edges, vertices);

            int totalWeight = 0;
            foreach (EdgeModel edge in MST)
            {
                totalWeight += edge.Weight;
                Console.WriteLine("Vertex {0} to Vertex {1} weight is: {2}", edge.Vertex1, edge.Vertex2, edge.Weight);
            }
            Console.WriteLine("Total Weight: {0}", totalWeight);
            Console.ReadLine();
        }

    }
}
