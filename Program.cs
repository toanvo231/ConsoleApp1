using System;
using System.Collections.Generic;

class Graph
{
    private int V;
    private List<List<int>> adj;

    public Graph(int v)
    {
        V = v;
        adj = new List<List<int>>(V);
        for (int i = 0; i < V; i++)
            adj.Add(new List<int>());
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
        adj[w].Add(v);
    }

    public void GreedyColoring()
    {
        int[] result = new int[V];
        for (int u = 0; u < V; u++)
            result[u] = -1;
        bool[] available = new bool[V];
        for (int cr = 0; cr < V; cr++)
            available[cr] = false;

        result[0] = 0;


        for (int u = 1; u < V; u++)
        {
            foreach (int i in adj[u])
            {
                if (result[i] != -1)
                    available[result[i]] = true;
            }

            int cr;
            for (cr = 0; cr < V; cr++)
            {
                if (available[cr] == false)
                    break;
            }
            result[u] = cr;

            for (int i = 0; i < adj[u].Count; i++)
            {
                if (result[adj[u][i]] != -1)
                    available[result[adj[u][i]]] = false;
            }
        }
        Console.WriteLine("The coloring of the graph is:");
        for (int u = 0; u < V; u++)
        {
            Console.WriteLine($"Vertex {u + 1} --> Color {result[u] + 1}");
        }
    }

    public static void Main(string[] args)
    {
        Graph g = new Graph(8);
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(0, 3);
        g.AddEdge(1, 2);
        g.AddEdge(1, 4);
        g.AddEdge(2, 3);
        g.AddEdge(2, 5);
        g.AddEdge(3, 6);
        g.AddEdge(2, 4);
        g.AddEdge(3, 5);
        g.AddEdge(4, 5);
        g.AddEdge(5, 6);
        g.AddEdge(4, 7);
        g.AddEdge(5, 7);
        g.AddEdge(6, 7);


        g.GreedyColoring();
    }
}
