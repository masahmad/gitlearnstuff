using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hack1
{
    class Program
    {


        /* 
         * Staircase input a integer and outputs a staircase    
         * 
         * x
         * xx
         * xxx
         * xxxx
         * xxxxx
         * xxxxxx
         * 
         * 
         * Summation input a array and get  total content sum
         *  e.g.  1,2,3,4 = 10
         * 
         * */


        static void Main(string[] args)
        {

            StairCase(6);
            Console.ReadLine();


            int[] arr1 = new int[] { 1,2,3,4 };
            
           Console.WriteLine ( summation(arr1));
            Console.ReadLine();
        }


        static void StairCase(int n)
        {
            for (int i = 1; i < n+1; i++)
            {
               string x= string.Concat(Enumerable.Repeat("*", i));
               Console.WriteLine(x);
            }

        }



        static int summation(int[] numbers)
        {


            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            
            return sum;

        }




    }
}
