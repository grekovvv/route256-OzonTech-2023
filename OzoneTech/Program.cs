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
            E e = new E();
            F f = new F();
            Test.AllTest(6, TestFileFolder.SandBox, f);
            Console.ReadLine();
        }
    }
}