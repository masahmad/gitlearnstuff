    /*
     * C# Program to Count the Number of 1's in the Entered Number
his C# Program Counts the Number of 1’s in the Entered Number. 
Here the array of numbers are obtained with its limit and number of 1’s in it is counted and displayed.
     */
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication16
    {
        class Program
        {
            static void Main(string[] args)
            {
                int m, count = 0;
                Console.WriteLine("Enter the Limit : ");
                m = int.Parse(Console.ReadLine());
                int[] a = new int[m];
                Console.WriteLine("Enter the Numbers :");
                for (int i = 0; i < m; i++)
                {
                    a[i] = Convert.ToInt32(Console.ReadLine());
                }
                foreach (int o in a)
                {
                    if (o == 1)
                    {
                        count++;
                    }
                }
                Console.WriteLine("Number of 1's in the Entered Number : ");
                Console.WriteLine(count);
                Console.ReadLine();
            }
        }
    }