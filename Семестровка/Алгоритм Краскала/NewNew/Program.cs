using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace NewNew
{

    class CreateGraph
    {
        private int CountOfVertex { get; set; }

        public CreateGraph(int vertex) { CountOfVertex = vertex; }

        public int[,] Create()
        {
            int[,] graph = new int[CountOfVertex, CountOfVertex];
            var random = new Random();

            for (int i = 0; i < CountOfVertex; i++)
            {
                int count = 0;
                while (count == 0)
                {
                    for (int j = i; j < CountOfVertex; j++)
                    {
                        if (random.Next(0, 2) == 1 && i != j)
                        {
                            graph[i, j] = 1;
                            graph[j, i] = 1;
                            count++;
                        }
                    }
                    if (i == CountOfVertex - 1)
                        break;
                }
            }

            return graph;
        }

        public int[,] GetGraphWithWeight(int[,] graph)
        {

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = i; j < graph.GetLength(1); j++)
                {
                    int randomWeight = new Random().Next(2, 20);
                    if (graph[i, j] == 1)
                    {
                        graph[i, j] = randomWeight;
                        graph[j, i] = randomWeight;
                    }
                }
            }

            return graph;
        }

        public static Graph GetGraph(int[,] matrix)
        {
            int[,] graph = matrix;
            List<Edge> e = new List<Edge>();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = i; j < graph.GetLength(1); j++)
                {
                    if (graph[i, j] != 0 && i != j)
                    {
                        e.Add(new Edge(i, j, graph[i, j]));
                    }

                }
            }
            return new Graph(e, matrix.GetLength(0));
        }
    }


    class Graph
    {
        public List<Edge> Edge = new List<Edge>();

        public int CountOfVertex;

        public Graph(List<Edge> edges, int countOfVertex)
        {
            Edge = edges;
            CountOfVertex = countOfVertex;
        }
    }

    class Edge
    {
        public int vertexX;

        public int vertexY;

        public int weight;

        public Edge(int x, int y, int weight)
        {
            vertexX = x;
            vertexY = y;
            this.weight = weight;
        }
    }

    class KruscalAlgorith
    {
        int[] sets;

        List<Edge> frame = new List<Edge>();

        Graph graph;

        public KruscalAlgorith(Graph graph)
        {
            this.graph = graph;
            sets = new int[graph.CountOfVertex];
            for (int i = 0; i < graph.CountOfVertex; i++)
            {
                sets[i] = i;
            }
        }

        public int Find(int x)
        {
            if (sets[x] == x) return x;
            return sets[x] = Find(sets[x]);
        }

        public void Union(int v1, int v2)
        {
            if (v1 < v2)
                sets[v2] = v1;
            else
                sets[v1] = v2;
        }

        public Graph Algorith(ref int count)
        {
            for (int i = 0; i < graph.CountOfVertex; i++)
            {
                for (int j = 0; j < graph.CountOfVertex - 1; j++)
                {
                    count++;
                    if (Find(graph.Edge[i].vertexX) != Find(graph.Edge[i].vertexY))
                    {
                        frame.Add(new Edge(graph.Edge[i].vertexX, graph.Edge[i].vertexY, graph.Edge[i].weight));
                        Union(Find(graph.Edge[i].vertexX), Find(graph.Edge[i].vertexY));
                    }
                }
            }

            return new Graph(frame, graph.CountOfVertex);
        }

    }


    class Program
    {
        static int[,] ReadFile(string path)
        {
            string text = File.ReadAllText(path);
            string[] lines = text.Split("\n");
            int[,] graph = new int[lines.Length - 1, lines.Length - 1];

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] str = lines[i].Split(",");
                for (int j = 0; j < str.Length - 1; j++)
                {
                    
                    graph[i, j] = int.Parse(str[j]);
                }
            }

            return graph;
        }

        static void WriteToFile(int[,] graph, int k)
        {
            string text = "";
            string path = @"D:\Output\Reuslt" + k + ".txt";
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    text += graph[i, j] + ",";
                }
                text += "\n";
            }
            File.WriteAllText(path, text + "\n#");
        }

        static int[,] ToMatrix(Graph frame)
        {
            int[,] graph = new int[frame.CountOfVertex, frame.CountOfVertex];
            
            for (int i = 0; i < frame.Edge.Count; i++)
            {
                graph[frame.Edge[i].vertexX, frame.Edge[i].vertexY] = frame.Edge[i].weight;
                graph[frame.Edge[i].vertexY, frame.Edge[i].vertexX] = frame.Edge[i].weight;
            }

            return graph;
        }



        static void Main(string[] args)
        {
            string mesureTime = @"D:\Measure.csv";
            string measure = "";
            for (int i = 0; i < 100; i++)
            {
                Stopwatch time = new Stopwatch();
                int count = 0;
                int[,] graph = ReadFile(@"D:\Input\Test" + i + ".txt");
                Graph newGraph = CreateGraph.GetGraph(graph);
                KruscalAlgorith kr = new KruscalAlgorith(newGraph);
                time.Start();
                Graph fr = kr.Algorith(ref count);
                time.Stop();
                measure += "Время - " + time.ElapsedTicks * 100.0 / 1000000.0 + ". Итераций - " + count + ". Число вершин - " + newGraph.CountOfVertex + "\n";
                int[,] frame = ToMatrix(fr);
                WriteToFile(frame, i);
            }
            Console.WriteLine(measure);
        }
    }
}
