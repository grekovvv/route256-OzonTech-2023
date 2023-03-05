using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneTechAlgorithm.Sandbox
{
    //не работает
    internal class J : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<string> list2 = new List<string>();
            var dictCount = int.Parse(input[0]);

            var rhythmDict = new SortedDictionary<int, Dictionary<string, List<string>>>();
            for (var i = 0; i < dictCount; i++)
            {
                var word = input[i+1];
                for (int j = 1; j <= word.Length; j++)
                {
                    var rhythmSuffix = word.Substring(word.Length - j);
                    if (!rhythmDict.ContainsKey(j))
                    {
                        rhythmDict.Add(j, new Dictionary<string, List<string>>());
                    }

                    if (!rhythmDict[j].ContainsKey(rhythmSuffix))
                    {
                        rhythmDict[j].Add(rhythmSuffix, new List<string>());
                    }

                    var list = rhythmDict[j][rhythmSuffix];
                    list.Add(word);
                }
            }

            var requestCount = int.Parse(input[dictCount+1]);

            for (int i = 0; i < requestCount; i++)
            {
                var word = input[dictCount + i + 2];
                for (int rhythmLen = word.Length; rhythmLen > 0; rhythmLen--)
                {
                    var rhythmSuffix = word.Substring(word.Length - rhythmLen);
                    if (!rhythmDict.ContainsKey(rhythmLen))
                    {
                        if (rhythmLen == 1)
                        {
                            list2.Add(rhythmDict.First().Value.First().Value.First());
                        }

                        continue;
                    }

                    if (!rhythmDict[rhythmLen].ContainsKey(rhythmSuffix))
                    {
                        if (rhythmLen == 1)
                        {
                            list2.Add(rhythmDict.First().Value.First().Value.First());
                        }

                        continue;
                    }

                    var rList = rhythmDict[rhythmLen][rhythmSuffix];
                    var rhythWord = rList.FirstOrDefault(x => x != word);
                    if (rhythWord != null)
                    {
                        list2.Add(rhythWord);
                        break;
                    }
                    else
                    {
                        if (rhythmLen == 1)
                        {
                            list2.Add(rhythmDict.First().Value.First().Value.First());
                        }
                    }
                }
            }
            return list2.ToArray();
        }
    }
}
