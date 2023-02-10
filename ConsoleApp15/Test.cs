using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    //@"C:\Users\v.grekov\Downloads\tests\01.a"
    public class Test
    {
        public static void AllTest(int numTest) //tests (1)
        {

        }
        public static bool IsPathExist()
        {
            string path = Path.GetFullPath(@"Tests\SandBoxOzoneTest\tests (1)\tests\01");
            bool aa = Path.Exists(pathQ);
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
