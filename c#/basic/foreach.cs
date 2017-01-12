using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace foreach_loop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[5]; // declaring array
 
            //Storing value in array element
            arr[0] = "Steven";
            arr[1] = "Clark";
            arr[2] = "Mark";
            arr[3] = "Thompson";
            arr[4] = "John";
 
            //retrieving value using foreach loop
            foreach (string name in arr)
            {
                Console.WriteLine("Hello " + name);
            }
            Console.ReadLine();
        }
    }
}
/*
Hello Steven
Hello Clark
Hello Mark
Hello Thompson
Hello John
*/
