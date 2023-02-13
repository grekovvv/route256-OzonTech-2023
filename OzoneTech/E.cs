using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonTech
{
    internal class E : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<string> list = new List<string>();
            int capacity = int.Parse(input[0]);
            int count = 0;
            int temp;
            bool isNotRight = false, isNewTaskStart = false;
            int[] arr = { };
            for (int i = 1; count < capacity; i = i + 2)
            {
                int[] otchet = input[i + 1].Split(' ').Select(x => int.Parse(x)).ToArray();

                for (int j = 0; j < otchet.Length; j++)
                {
                    isNotRight = false;
                    isNewTaskStart = false;
                    temp = otchet[j];
                    for (int k = j + 1; k < otchet.Length; k++)
                    {
                        if (isNewTaskStart)
                        {
                            if (otchet[k] == temp)
                            {
                                isNotRight = true;
                                break;
                            }
                        }
                        else
                        {
                            //находим новый таск
                            if (otchet[k] != temp)
                            {
                                isNewTaskStart = true;
                            }
                            else
                            {
                                j++;
                            }
                        }
                    }
                    if (isNotRight) break;
                    
                }
                if (!isNotRight)
                {
                    list.Add("YES");
                }
                else
                {
                    list.Add("NO");
                }
                count++;

            }
            return list.ToArray();
        }
    }
}

