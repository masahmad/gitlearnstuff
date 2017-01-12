using System;

class Program
{
    static void Main()
    {
	string[] array = { "cat", "dog", "bird", "fish" };

	// The dog string is at index 1.
	int dogIndex = Array.IndexOf(array, "dog");
	Console.WriteLine(dogIndex);

	// There is no monkey string in the array.
	// ... So IndexOf returns -1.
	int monkeyIndex = Array.IndexOf(array, "monkey");
	Console.WriteLine(monkeyIndex);
    }
}
/*
1 ....at pos 1
-1 ...(no monkey)
*/
