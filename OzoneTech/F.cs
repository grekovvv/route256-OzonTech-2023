using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonTech
{
    internal class F : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<string> list = new List<string>();
            int capacity = int.Parse(input[0]);
            int count = 0, count2, count3;
            int temp;
            int capacityTimeArr;
            bool isRight = true, badValue = false;
            int[] arr = { };
            for (int i = 1; count < capacity; i = i + capacityTimeArr + 1)
            {
                isRight = true;
                badValue = false;
                count2 = 0;
                count3 = 0;
                capacityTimeArr = int.Parse(input[i]);

                //Первая валидация на правильность введенных значений и нарушение левых и правых границ
                for (int j = i; count2 < capacityTimeArr; j++)
                {
                    int[] time = input[j+1].Split(':', '-').Select(x => int.Parse(x)).ToArray();

                    for (int g = 0; g < time.Length; g++)
                    {
                        if(g == 0 || g == 3)
                        {
                            if (time[g] > 23 || time[g] < 0) { badValue = true; break; }
                            else if (time[g] > 59 || time[g] < 0) { badValue = true; break; }
                        }
                    }

                    if (time[0] > time[3])
                    {
                        break;
                    }
                    else
                    {
                        if (time[0] == time[3])
                        {
                            if (time[1] > time[4])
                            {
                                break;
                            }
                            else
                            {
                                if (time[1] == time[4])
                                {
                                    if (time[2] > time[5])
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }



                    count2++;
                }
//Если произошёл break
                if (count2 != capacityTimeArr) 
                    isRight = false;

                if (isRight)
                {
                    for (int j = i; count3 < capacityTimeArr; j++)
                    {
                        int[] time = input[j + 1].Split(':', '-').Select(x => int.Parse(x)).ToArray();

                        for (int h = 0; h < capacityTimeArr; h++)
                        {

                        }

                        count3++;
                    }
                }

                if (isRight && !badValue)
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
