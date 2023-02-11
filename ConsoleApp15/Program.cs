using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] testInput = Test.GetFileData(@"Tests\SandBoxOzoneTest\tests (1)\tests\01");
            string[] testOutput = Test.GetFileData(@"Tests\SandBoxOzoneTest\tests (1)\tests\01.a");
            string[] result = { };
            for (int i = 0; i < testInput.Length; i++)
            {
                string str = testInput[i];
                int a, b;
                string[] arr = str.Split(' ');
                if (arr.Count() > 1)
                {
                    bool isAint = Int32.TryParse(arr[0], out a);
                    bool isBint = Int32.TryParse(arr[1], out b);
                    if (isAint && isBint)
                    {
                        //Console.WriteLine(a + b);
                        result.Append($"{a + b}");
                    }
                }
            }
            Test.Compare(result, testOutput);
            /*while (true)
            {
                string? str = Console.ReadLine();
                if (str == null) break;
                int a, b;
                string[] arr = str.Split(' ');
                if (arr.Count() > 1)
                {
                    bool isAint = Int32.TryParse(arr[0], out a);
                    bool isBint = Int32.TryParse(arr[1], out b);
                    if (isAint && isBint)
                    {
                        Console.WriteLine(a + b);
                    }
                }
            }*/
        }

        public static string[] Method2(string testInput)
        {
            string[] result = { };

            return result;
        }
    }
}