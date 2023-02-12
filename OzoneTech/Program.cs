using System;
using System.Security.Cryptography.X509Certificates;
using OzoneTechAlgorithm.Enum;

namespace OzonTech
{
    internal class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            D d = new D();
            Test.AllTest(4, TestFileFolder.SandBox, d);
            Console.ReadLine();
        }
    }
}