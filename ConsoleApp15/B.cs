using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class B : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<string> list = new List<string>();
            int result;
            int capacity = int.Parse(input[0]);
            int count = 0;
            for (int i = 1; count < capacity; i=i+2)
            {
                result = 0;
                int itemsCount = int.Parse(input[i]);
                int[] itemCost = new int[itemsCount];
                string str_itemCost2 = input[i+1];
                string[] str_itemCost = str_itemCost2.Split(' ');

                for (int j = 0; j < str_itemCost.Length; j++)
                {
                    itemCost[j] = (Convert.ToInt32(str_itemCost[j]));
                }

                int[] itemCostDistinctArray = (int[])itemCost.Distinct().ToArray();
                for (int k = 0; k < itemCostDistinctArray.Length; k++)
                {
                    int numberDistinct = itemCostDistinctArray[k];
                    int numberSame = itemCost.Where(x => x == numberDistinct).Count();
                    result += numberDistinct * (numberSame - (numberSame / 3));
                }
                list.Add(result.ToString());
                count++;
            }
            return list.ToArray();
        }
    }
}
