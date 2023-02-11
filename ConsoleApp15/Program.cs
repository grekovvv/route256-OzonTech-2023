using System;
using System.Security.Cryptography.X509Certificates;
using OzoneTechAlgorithm.Enum;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            Test.AllTest(3, TestFileFolder.SandBox, c);
            Console.ReadLine();
        }
    }
}