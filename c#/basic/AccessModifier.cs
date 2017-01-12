    /*
     * C# Program to Illustrate the Use of Access Specifiers
     */
    using System;
    namespace accessspecifier
    {
        class Program
        {
            static void Main(string[] args)
            {
                two B = new two();
                B.show();
            }
        }
        class one
        {
            private int x;
            protected int y;
            internal int z;
            public int a;
            protected internal int b;
        }
        class two : one
        {
            public void show()
            {
                Console.WriteLine("Values are : ");
                //x=10;
                y = 20;
                z = 30;
                a = 40;
                b = 50;
                // Console.WriteLine(+x); // Error x is not accessible
                Console.WriteLine(y);
                Console.WriteLine(z);
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.ReadLine();
            }
        }
    }

	/*
Values are :
20
30
40
50
*/