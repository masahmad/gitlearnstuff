    /*

     *  C# Program to Illustrate Hierarchical Inheritance
This C# Program Illustrates Hierarchical Inheritance. Here Single parent and multiple child and when more than one derived class are created from single base class is called C# Hierarchical Inheritance.

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

                Principal g = new Principal();

                g.Monitor();

                Teacher d = new Teacher();

                d.Monitor();

                d.Teach();

                Student s = new Student();

                s.Monitor();

                s.Learn();

                Console.ReadKey();

            }

            class Principal

            {

                public void Monitor()

                {

                    Console.WriteLine("Monitor");

                }

            }

            class Teacher : Principal

            {

                public void Teach()

                {

                    Console.WriteLine("Teach");

                }

            }

            class Student : Principal

            {

                public void Learn()

                {

                    Console.WriteLine("Learn");

                }

            }

        }

    }

/*

Monitor
Monitor
Teach
Monitor
Learn

*/