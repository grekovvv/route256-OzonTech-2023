using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    //@"C:\Users\v.grekov\Downloads\tests\01.a"
    public class Test
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numTest"></param>
        /// <param name=""></param>
        public static void AllTest(int numTest, string nameFolder) //tests (1)
        {
            if ((nameFolder == "Contest" || nameFolder == "Sanbox") == false) return;
            int i = 1;
            string pathIn = "";
            string pathOut = "";
            while (true)
            {
                pathIn = $"Tests\\SandBoxOzoneTest\\tests ({numTest})\\tests\\0{i}";
                pathOut = $"Tests\\SandBoxOzoneTest\tests ({numTest})\\tests\\0{i}.a";
                bool pathInExist = IsPathExist(pathIn);
                bool pathOutExist = IsPathExist(pathOut);
                if (pathInExist && pathOutExist)
                {
                    string[] testInput = Test.GetFileData(pathIn);
                    string[] testOutput = Test.GetFileData(pathOut);
                }
                


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
            string[] result = { }; 
            foreach (string line in System.IO.File.ReadLines(File))
            {
                string? str = line;
                if (str == null) break;
                result.Append(str);
            }
            return result;
        }

        public static bool Compare(string[] result, string[] _out)
        {
            if (result.Length != _out.Length)
            {
                Console.WriteLine("Ошибка! Массивы не равны.");
                return false;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != _out[i])
                {
                    Console.WriteLine($"Ошибка! - {result[i]} != {_out[i]}");
                    return false;
                }

            }
            Console.WriteLine($"Тест пройден успешно!");
            return true;
        }
    }
}
