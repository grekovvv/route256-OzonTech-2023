using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class A : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string str = input[i];
                int a, b;
                string[] arr = str.Split(' ');
                if (arr.Count() > 1)
                {
                    bool isAint = Int32.TryParse(arr[0], out a);
                    bool isBint = Int32.TryParse(arr[1], out b);
                    if (isAint && isBint)
                    {
                        list.Add($"{a + b}");
                    }
                }
            }
            return list.ToArray();
        }
    }
}