using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OzoneTechAlgorithm.Sandbox
{
    internal class H : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            /*List<string> list = new List<string>();

            int countSet = Convert.ToInt16(input[0]);
            int caret = 1;

            for (int s = 0; s < countSet; s++)
            {
                int[] startVal = input[caret].Split(' ').Select(x => int.Parse(x)).ToArray();
                int n = startVal[0]; //n - кол-во строк 
                int m = startVal[1]; //m - кол-во символов в каждой строке

                var forSearchUnique = new List<char>();
                string[,] maxtrix = new string[n, m];
                for (int i = 0; i < n; i++)
                {
                    char[] data = input[caret + i + 1].ToArray();
                    for (int j = 0; j < m; j++)
                    {
                        maxtrix[i, j] = data[j].ToString();
                        forSearchUnique.Add(data[j]);
                    }
                    
                }

                string[] unique = forSearchUnique.Distinct().Select(x => x.ToString()).Where(x => x != ".").ToArray();


                caret += n+1;
            }





            return list.ToArray();*/

            List<string> list = new List<string>();
            int caret = 1;
            int entries = Convert.ToInt16(input[0]);
            for (int i = 0; i < entries; i++)
            {
                int[] dimensions = input[caret].Split(" ").Select(x => int.Parse(x)).ToArray();
                int height = dimensions[0];
                int width = (dimensions[1] + 1) / 2;
                char[,] map = new char[height, width];
                bool[,] visited = new bool[height, width];


                //Read hexagon
                for (int j = 0; j < height; j++)
                {
                    char[] line = input[caret + j + 1].ToArray();
                    int kk = 0;
                    for (int k = 0; k < line.Length; k++)
                    {
                        if (kk == width)
                        {
                            break;
                        }
                        if (line[k] == '.')
                        {
                            continue;
                        }
                        map[j, kk] = line[k];
                        kk++;
                    }
                }
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        if (map[j, k] == 0)
                        {
                            visited[j, k] = true;
                        }
                    }
                }

                List<HexRegion> _r = new();
                for (int j = 0; j < height; j++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        if (visited[j, k])
                        {
                            continue;
                        }
                        _r.Add(BFS(map, visited, j, k));
                    }
                }
                Dictionary<int, List<HexRegion>> regions = _r.GroupBy(hr => hr.Color).ToDictionary(g => g.Key, g => g.ToList());
                list.Add(regions.Any(r => r.Value.Count > 1) ? "NO" : "YES");
                caret += height + 1;
            }
            return list.ToArray();
        }

        static readonly int[] Directions = new int[6] { 0, 1, 2, 3, 4, 5 };
        static readonly int[,,] oddr_direction_differences = new int[2, 6, 2] {
        // even rows 
        {   { 1, 0 }, { 0, -1 }, { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, 1 } },
        // odd rows
        {   { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, 0 }, { 0, 1 }, { 1, 1 } }
    };
        static Hexagon oddr_offset_neighbor(int X, int Y, int direction)
        {
            var parity = Y & 1;
            var diffX = oddr_direction_differences[parity, direction, 0];
            var diffY = oddr_direction_differences[parity, direction, 1];
            return new Hexagon() { x = X + diffX, y = Y + diffY };
        }

        static HexRegion BFS(char[,] map, bool[,] vis, int row, int col)
        {
            HexRegion result = new(map[row, col]);
            Queue<Hexagon> q = new();
            q.Enqueue(new Hexagon() { x = col, y = row, color = map[row, col] });
            vis[row, col] = true;
            int height = map.GetLength(0);
            int width = map.GetLength(1);

            while (q.Count > 0)
            {
                var hex = q.Peek();
                result.AddEdge(hex);
                q.Dequeue();
                foreach (var d in Directions)
                {
                    var neigh = oddr_offset_neighbor(hex.x, hex.y, d);
                    if (
                        neigh.x < 0 ||
                        neigh.y < 0 ||
                        neigh.x >= width ||
                        neigh.y >= height ||
                        map[neigh.y, neigh.x] == 0 ||
                        map[neigh.y, neigh.x] != hex.color ||
                        vis[neigh.y, neigh.x] == true
                        )
                    {
                        continue;
                    }
                    neigh.color = map[neigh.y, neigh.x];
                    q.Enqueue(neigh);
                    result.AddEdge(neigh);
                    vis[neigh.y, neigh.x] = true;
                }
            }
            return result;
        }
    }
    struct Hexagon
    {
        public int x;
        public int y;
        public int color;
    }

    class HexRegion
    {
        private int _C;
        private LinkedList<Hexagon> _adj = new();
        public int Color { get { return _C; } }
        public LinkedList<Hexagon> Adj { get { return _adj; } }
        public HexRegion(int c) => _C = c;

        public void AddEdge(Hexagon hex)
        {
            if (!_adj.Any(h => h.x == hex.x && h.y == hex.y))
                _adj.AddLast(hex);
        }
    }
}
            /*1) есть некий R, у которого нет связи с другими R, при этом други R есть
             *2) Есть некий R, у которого есть связи с другими R, также есть другой R, у которого есть связи с R
             *Но при сравнении, у них нет пересекающихся связей.
             *
             * 
            */