    /*
     * C# Program to Perform Unboxing Operation
	 This C# Program Performs Unboxing Operation. Here Unboxing is an explicit conversion from the type object 
	 to a value type or from an interface type to a value type that implements the interface.
     */
    using System;
    class sample
    {
        int data;
        void insert(object x)
        {
            data = (int)x * 5;
        }
        object delete()
        {
            data=0;
            return (object)data;
        }
        public static void Main()
        {
            sample s = new sample();
            s.insert(10);
            Console.WriteLine("Data : {0}", s.data);
            Console.WriteLine("Data : {0}", s.delete());
            Console.ReadLine();
        }
    }
	
/*
Data : 50
Data : 0
	*/