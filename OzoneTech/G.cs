using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonTech
{
    internal class G : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<string> list = new List<string>();
             
            int[] startVal = input[0].Split(' ').Select(x => Int32.Parse(x)).ToArray();
            int n = startVal[0]; //n - кол-во пользователей
            int m = startVal[1]; //m - кол-во пар друзей

            //List<List<int>> list2 = new List<List<int>>();



            int[,] s = new int[m, 2];
            for (int i = 1; i <= m; i++)
            {
                int[] couple = input[i].Split(' ').Select(x => Int32.Parse(x)).ToArray();
                s[i-1, 0] = couple[0];
                s[i-1, 1] = couple[1];
            }

            var a = s;
            return list.ToArray();
        }
    }
}
