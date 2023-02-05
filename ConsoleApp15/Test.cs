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
        public static string[] GetInput(string File)
        {
            string[] result = { }; 
            foreach (string line in System.IO.File.ReadLines(File))
            {
                string? str = line;
                if (str == null) break;
                Console.WriteLine(str);
                result.Append(str);
            }
            return result;
        }

        public static string[] GetOutput(string File)
        {
            string[] result = { };
            foreach (string line in System.IO.File.ReadLines(File))
            {
                string? str = line;
                if (str == null) break;
                Console.WriteLine(str);
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
                if (result[i] != _out[i]) return false;
            }
            return true;
        }

        static void TestMethod(string testsFile, string testResult)
        {
            List<string> result = new List<string>();
            foreach (string line in System.IO.File.ReadLines(filePath))
            
            {
                string? str = line;
                if (str == null) break;
                Console.WriteLine(str);
                result.Add(str);
            }    
        }
    }
}
