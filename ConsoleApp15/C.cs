using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class C : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<string> list = new List<string>();
            string result = "";
            int capacity = int.Parse(input[0]);
            int count = 0;
            for (int i = 1; count < capacity; i = i + 2)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                int[] devCount = new int[int.Parse(input[i])];
                string[] str_devMaster = input[i + 1].Split(' ');
                int[] devMaster = new int[str_devMaster.Length];

                for (int k = 0; k < devCount.Length; k++)
                {
                    dict.Add(k + 1, (Convert.ToInt32(str_devMaster[k])));
                }

                int curDiff, minDiff, curDev;

                foreach (var me in dict)
                {
                    curDiff = -1;
                    curDev = -1;
                    minDiff = int.MaxValue;
                    foreach (var you in dict)
                    {
                        if (me.Key == you.Key) continue;
                        curDiff = Math.Abs(me.Value - you.Value);
                        if (curDiff < minDiff)
                        {
                            minDiff = curDiff;
                            curDev = you.Key;
                        }
                    }

                    result = $"{me.Key} {curDev}";
                    list.Add(result);

                    dict.Remove(me.Key);
                    dict.Remove(curDev);

                }
                count++;
                if (count < capacity) list.Add("");
            }
            
            return list.ToArray();
        }
    }
}
