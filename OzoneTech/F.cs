using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OzonTech
{
    //Задача решается через парсинг в DateTime
    //В начале решения я просто паршу стринг, это в данном случае неверно, лучше решить всё через DateTime
    //Флаг вам в руки, контрибьютеры!

    //До 14-ого теста включительно прошло дальше смотреть не стал,
    //так как 7 минут заняли 14 тестов. Долго.
    internal class F : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<string> list = new List<string>();
            int capacity = int.Parse(input[0]);
            int count = 0, count2, count3, count4, count5, count6;
            int temp;
            int capacityTimeArr;
            bool isRight = true, badValue = false;
            int[] arr = { };
            for (int i = 1; count < capacity; i = i + capacityTimeArr + 1)
            {
                badValue = false;
                isRight = true;
                count2 = 0;
                count3 = 0;
                count5 = 0;
                count6 = 0;
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
                        }
                        else
                        {
                            if (time[g] > 59 || time[g] < 0) { badValue = true; break; }
                        }
                        
                    }

                    if (badValue) break;

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
                    if (capacityTimeArr > 1)
                    {
                        for (int d = i+1; count3 < capacityTimeArr; d++)
                        {
                            string[] time1 = input[d].Split('-');
                            count4 = 1 + count3;
                            for (int h = d + 1; count4 < capacityTimeArr; h++)
                            {
                                string[] time2 = input[h].Split('-');

                                if (time1[0] == time2[0] || time1[0] == time2[1] 
                                    || time1[1] == time2[0] || time1[1] == time2[1])
                                {
                                    badValue = true; break;
                                }
                                count4++;
                            }
                            if (badValue) break;
                            count3++;
                        }


                        if (!badValue)
                        {
                            for (int d = i + 1; count5 < capacityTimeArr; d++)
                            {
                                DateTime[] dateTime1 = Array.ConvertAll(input[d].Split('-'), s => DateTime.Parse(s));
                                count6 = 1 + count5;
                                for (int h = d + 1; count6 < capacityTimeArr; h++)
                                {
                                    DateTime[] dateTime2 = Array.ConvertAll(input[h].Split('-'), s => DateTime.Parse(s));

                                    DateTime dateStart1 = dateTime1[0];
                                    DateTime dateEnd1 = dateTime1[1];
                                    DateTime dateStart2 = dateTime2[0];
                                    DateTime dateEnd2 = dateTime2[1];

                                    if (dateStart1 > dateStart2 && dateStart1 < dateEnd2
                                        || dateEnd1 > dateStart2 && dateEnd1 < dateEnd2
                                        || dateStart2 > dateStart1 && dateStart2 < dateEnd1
                                        || dateEnd2 > dateStart1 && dateEnd2 < dateEnd1)
                                    {
                                        badValue = true; break;
                                    }

                                    if (badValue) break;
                                    count6++;
                                }
                                if (badValue) break;
                                count5++;
                            }
                        }
                    }
                }

                if (badValue) isRight = false;

                if (isRight)
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