    /*
     *  C# Program to Illustrate Single Inheritance
This C# Program Illustrates Single Inheritance. Here In single inheritance we have single base class that is inherited by the derived class and the derived class has all the features of the base class and can add some new features and italso depends on the access specifier that is used at the time of base class inheritance.
Here is source code of the C# Program to Caluculate the power exponent value. The C# program is successfully compiled and executed with Microsoft Visual Studio. The program output is also shown below. 
     */
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace Inheritance
    {
        class Program
        {
            static void Main(string[] args)
            {
                Teacher d = new Teacher();
                d.Teach();
                Student s = new Student();
                s.Learn();
                s.Teach();
                Console.ReadKey();
            }
            class Teacher
            {
                public void Teach()
                {
                    Console.WriteLine("Teach");
                }
            }
            class Student : Teacher
            {
                public void Learn()
                {
                    Console.WriteLine("Learn");
                }
            }
        }
    }
/* output
Teach
Learn
Teach
*/