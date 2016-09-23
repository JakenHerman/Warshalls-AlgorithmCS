using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;




namespace Warshalls
{


    // Declare the generic class.
    public class GenericAdj<T>
    {
        public T[] loc;

        public void set_numeric(T gen_to_num_index, int V)
        {
            loc = new T[V];
            int knt = 0;

            bool exists = Array.Exists(loc, element => element.Equals(gen_to_num_index));
            if (!exists)
            {
                loc[knt] = gen_to_num_index;
                Console.WriteLine("Location of {0}, is {0}", gen_to_num_index, knt);
                knt++;
            }
            else
            {
                int index = 0;
                for (int i = 0; i < loc.Length; i++)
                {
                    if (loc[i].Equals(gen_to_num_index))
                        index = i;
                }
                loc[index] = gen_to_num_index;
                Console.WriteLine("Location of {0}, is {0}", gen_to_num_index, index);
            }
        }

        void adjacency(T[,] graph)
        {

        }
    }


    class Program
    {
        private int V;
        private Int32[,] M;

        public void adjacency(int[,] graph)
        {
            this.V = graph.GetLength(0);
            M = new Int32[V, V];

            for (int l = 0; l < V; l++)
                for (int n = 0; n < V; n++)
                    M[l, n] = graph[l, n];


            Console.Write("  "); //set up label
            //apply warshalls algorithm
            for(int i = 0; i < V; i++)
            {
                Console.Write(i + " ");
                for(int j = 0; j < V; j++)
                {
                    if (M[j, i] > 0)
                    {
                        for(int k = 0; k < V; k++)
                        {
                            M[j, k] = M[j, k] + M[i, k];
                        }
                    }
                }
            }

        }


        /** Funtion to display the adjacency matrix **/
        public void printAdjacency()
        {
            for(int i = 0; i < V; i++)
            {
                Console.WriteLine();
                Console.Write(i + " ");
                for(int j = 0; j < V; j++)
                {
                    if(M[i, j] > 0)
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
            }
        }


        /** Main function **/
        static void Main(string[] args)
        {
            Console.WriteLine("Warshall Algorithm\nWhat file to read?\n");
            String filename = Console.ReadLine();
            /** Make an object of Warshall class **/
            Program w = new Program();
            /** Accept number of vertices from win.txt **/
            int V = Convert.ToInt32(File.ReadLines(filename).First());
            /** Accept Type From User **/
            int type = Convert.ToInt32(File.ReadLines(filename).ElementAt(1));
            GenericAdj<int> genInt;
            GenericAdj<string> genStr;
            GenericAdj<float> genFlt;
            GenericAdj<char> genChar;

            /** get graph **/
            int[,] graph = new int[V, V];
            for (int z = 0; z < V; z++)
                graph[z, z] = 0;

            int location = 0;
            int knt = 2;
            for (int i = 2; i < V*2; i++)
            {
                if (type == 99)
                {
                    genInt = new GenericAdj<int>();
                    genInt.set_numeric(Convert.ToInt32(File.ReadLines(filename).ElementAt(i)), V);
                }
                else if (type == 98)
                    genStr = new GenericAdj<string>();
                else if (type == 97)
                    genFlt = new GenericAdj<float>();
                else if (type == 96)
                    genChar = new GenericAdj<char>();
                else //default to int
                {
                    genInt = new GenericAdj<int>();
                    genInt.set_numeric(Convert.ToInt32(File.ReadLines(filename).ElementAt(i)), V);
                }
                // graph[Convert.ToInt32(File.ReadLines(filename).ElementAt(i + knt)) -1,
                //      Convert.ToInt32(File.ReadLines(filename).ElementAt(i + knt + 1)) -1] = 1;
                knt += 1;
            }

            w.adjacency(graph);
            w.printAdjacency();
        }

        
    }
}