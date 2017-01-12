

/* 
Above code shows how to sort an Array in ascending order, like that, you can sort an Array in descending order. 
We can use Array.Reverse method for reverses the sequence of the elements in the entire one-dimensional Array.
*/


string[] ArrStr = new string[] { "c", "a", "d", "b" };
Array.Sort(ArrStr);
foreach (var str in ArrStr)
{
    MessageBox.Show(str);
}




// reverse

int[] array = new int[] { 3, 1, 4, 5, 2 };
Array.Sort(array);
Array.Reverse(array);
foreach (var str in array)
{
    MessageBox.Show(str.ToString());
}