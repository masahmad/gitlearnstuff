using System;

class Program
{
    static void Main()
    {
	string[] pets = { "dog", "cat", "bird" };

	// ... Loop with the foreach keyword.
	foreach (string value in pets)
	{
	    Console.WriteLine(value);
	}
    }
}
/*
dog
cat
bird
*/
