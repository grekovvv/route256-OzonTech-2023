using OzoneTechAlgorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OzoneTechAlgorithm.Sandbox
{
    //Все тесты пройдены за 11 секунд
    internal class I : MainInterface
    {
        public string[] MainMethod(string[] input)
        {
            List<long> list = new List<long>();

            var countList = input[0].Split(" ").Select(x => long.Parse(x)).ToArray();
            var procCount = countList.First();
            var taskCount = countList.Last();

            var procList = input[1].Split(" ").Select(x => long.Parse(x)).ToArray();
            var procFreeSet = new SortedSet<long>();
            var procBusySet = new SortedSet<Proc>(new ProcComparer());
            long workPowerCommon = 0;

            foreach (var power in procList)
            {
                procFreeSet.Add(power);
            }

            for (int i = 0; i < taskCount; i++)
            {
                var taskList = input[i+2].Split(" ").Select(x => long.Parse(x)).ToList();
                var taskStartTime = taskList.First();
                var taskDuration = taskList.Last();

                if (procBusySet.Count > 0)
                {
                    var setCount = procBusySet.Count;

                    for (int j = 0; j < setCount; j++)
                    {
                        var procBusy = procBusySet.FirstOrDefault();

                        if (procBusy.EndWorkTime <= taskStartTime)
                        {
                            procBusySet.Remove(procBusy);
                            procBusy.EndWorkTime = 0;

                            procFreeSet.Add(procBusy.Power);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (procFreeSet.Count > 0)
                {
                    var procPower = procFreeSet.First();
                    procFreeSet.Remove(procPower);

                    list.Add(taskDuration * procPower);
                    procBusySet.Add(new Proc(procPower) { EndWorkTime = taskStartTime + taskDuration });
                }
            }

            long temp = list.Sum();
            string[] arr = new string[1] { list.Sum().ToString() };
            return arr;
        }
      
    }

    public class Proc
    {
        public Proc(long power)
        {
            Power = power;
        }

        public long Power { get; set; }

        public long EndWorkTime { get; set; }
    }

    public class ProcComparer : IComparer<Proc>
    {
        public int Compare(Proc x, Proc y)
        {
            //first by EndWorkTime
            var result = x.EndWorkTime.CompareTo(y.EndWorkTime);

            //then power
            if (result == 0)
                result = x.Power.CompareTo(y.Power);

            return result;
        }
    }
}
