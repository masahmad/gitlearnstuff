// Initialize array for example 
//	Array.Resize(ref array, 3);
//In the above code we resize the array to 3 elements.

/*
An array can be resized with Array.Resize < T > Method , that means We make an array bigger or smaller. 
Array.Resize < T > Method Changes the number of elements of a one-dimensional array to the specified new size.

Array.Resize < T > - T is the type of the elements of the array.

This method should be used with only one dimensional Array. This method allocates a new array with the specified size, 
copies elements from the old array to the new one, and then replaces the old array with the new one.
*/


char[] array = new char[5]; 
array[0] = 'A'; 
array[1] = 'B'; 
array[2] = 'C'; 
array[3] = 'D'; 
array[4] = 'E'; 
for (int i = 0; i < array.Length; i++) 
{
	MessageBox.Show (array[i].ToString ()); 
} 
Array.Resize(ref array, 3); 
for (int i = 0; i < array.Length; i++) 
{ 
MessageBox.Show(array[i].ToString ()); 
}