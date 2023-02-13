using OzoneTechAlgorithm.Interface;
using OzoneTechAlgorithm.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OzonTech
{
    public class Test
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numTest">test (1)</param>
        /// <param name="nameFolder">SandBox or Contest</param>
        public static void AllTest<T>(int numTest, TestFileFolder nameFolder, T testClass) where T : class
        {
            Stopwatch TimeOneTest = new Stopwatch();
            Stopwatch AllTests = new Stopwatch();
            AllTests.Start();

            MainInterface? testClassVerified = testClass as MainInterface;
            if (testClassVerified == null) return;

            int i = 1;
            string pathIn = "";
            string pathOut = "";
            string[] testIn = { };
            string[] testResult = { };
            string[] testOut = { };
            string testNumPath = "";

            while (true)
            {
                TimeOneTest.Start();
                if (i<10)
                {
                    testNumPath = string.Format($"0{i}");
                }
                else
                {
                    testNumPath = i.ToString();
                }

                pathIn = $"Tests\\{nameFolder}OzoneTest\\tests ({numTest})\\tests\\{testNumPath}";
                pathOut = $"Tests\\{nameFolder}OzoneTest\\tests ({numTest})\\tests\\{testNumPath}.a";
                bool pathInExist = IsPathExist(pathIn);
                bool pathOutExist = IsPathExist(pathOut);
                if (!pathInExist && !pathOutExist)
                {
                    AllTests.Stop();
                    Console.WriteLine($"Все тесты пройдены! | Общее время выполнения: {AllTests.Elapsed.TotalSeconds} seconds" + "\n");
                    return;
                }

                testIn = GetFileData(pathIn);
                testOut = GetFileData(pathOut);
                testResult = testClassVerified.MainMethod(testIn);
                if(!Compare(testResult, testOut, i)) return;

                TimeOneTest.Stop();
                Console.Write($" | Время выполнения: {TimeOneTest.Elapsed.TotalSeconds} seconds" + "\n");
                TimeOneTest.Reset();

                i++;
            }
            
        }
        public static bool IsPathExist(string path)
        {
            string str_path = Path.GetFullPath(path);
            return Path.Exists(str_path);
        }

        public static string[] GetFileData(string File)
        {
            List<string> list = new List<string>();
            foreach (string line in System.IO.File.ReadLines(File))
            {
                string? str = line;
                if (str == null) break;
                list.Add(str);
            }
            return list.ToArray();
        }

        public static bool Compare(string[] result, string[] _out, int testNum)
        {
            if (result.Length != _out.Length)
            {
                Console.WriteLine($"ERROR! Массивы не равны.  | test - {testNum}");
                return false;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != _out[i])
                {
                    Console.WriteLine($"ERROR! - {result[i]} != {_out[i]} | test - {testNum}");
                    return false;
                }
            }
            Console.Write($"Тест {testNum} пройден успешно!");
            return true;
        }
    }
}
