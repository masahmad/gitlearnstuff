using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ConsoleApplication2
{
    public class TestDelegate
    {
        //Declaration
        //Creating Delegates with no parameters and no return type.
        public delegate void FirstDelegate();
 
        public void fun1()
        {
            Console.WriteLine("I am Function 1");
        }
        public void fun2()
        {
            Console.WriteLine("I am Function 2");
        }
        public void fun3()
        {
            Console.WriteLine("I am Function 3");
        }
    }
 
    class Program
    {
        static void Main(string[] args)
        {
            TestDelegate testdelegate = new TestDelegate();
//Instantiation
            TestDelegate.FirstDelegate fd1 = new TestDelegate.FirstDelegate(testdelegate.fun1);
            TestDelegate.FirstDelegate fd2 = new TestDelegate.FirstDelegate(testdelegate.fun2);
            TestDelegate.FirstDelegate fd3 = new TestDelegate.FirstDelegate(testdelegate.fun3);
 
//Invocation 
           fd1();
            fd2();
            fd3();
 
            Console.ReadKey();
        }
    }
}

/*
I am Function 1
 
I am Function 2
 
I am Function 3
*/

