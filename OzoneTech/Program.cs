using System;
using System.Security.Cryptography.X509Certificates;
using OzoneTechAlgorithm.Enum;
using OzoneTechAlgorithm.Sandbox;

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
            G g = new G();
            H h = new H();
            I i = new I();
            J j = new J();
            Test.AllTest(1, TestFileFolder.SandBox, a);
            Console.ReadLine();
        }
    }
}