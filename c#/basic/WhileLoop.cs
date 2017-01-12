using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace While_Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, res, i;
 
            Console.WriteLine("Enter a number");
            num1 = Convert.ToInt32(Console.ReadLine());
 
            i = 1; //Initialization
            //Check whether condition matches or not
            while (i <= 10)
            {
                res = num1 * i;
                Console.WriteLine("{0} x {1} = {2}", num1, i, res);
                i++; //Increment by one
            }
            Console.ReadLine();
        }
    }
}
/*
Enter a number
8
8 x 1 = 8
8 x 2 = 16
8 x 3 = 24
8 x 4 = 32
8 x 5 = 40
8 x 6 = 48
8 x 7 = 56
8 x 8 = 64
8 x 9 = 72
8 x 10 = 80
*/