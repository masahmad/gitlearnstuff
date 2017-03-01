using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hack2
{
    class Program
    {
       


            static void Main(string[] args)
	{
		Circle C1 = new Circle( Convert.ToDouble(Console.ReadLine()) );
		Console.WriteLine( C1.getArea() );

        double[] dimensions = Console.ReadLine().Split().Select(x => Convert.ToDouble(x)).ToArray();
        Rectangle R1 = new Rectangle(dimensions[0], dimensions[1]);
        Console.WriteLine(R1.getArea());

        Circle C2 = new Circle(Convert.ToDouble(Console.ReadLine()));
        Console.WriteLine(C2.getArea());

        Square S1 = new Square(Convert.ToDouble(Console.ReadLine()));
        Console.WriteLine(S1.getArea());

        dimensions = Console.ReadLine().Split().Select(x => Convert.ToDouble(x)).ToArray();
        Rectangle R2 = new Rectangle(dimensions[0], dimensions[1]);
        Console.WriteLine(R2.getArea());

        Console.ReadLine();

        }
    }




   


   



    public class Circle 
    {

        double r;
        public Circle( double radius)
        {
            r = radius;
           
        }

        public double getArea()
        {
            return  Math.Ceiling(3.14159265 * r * r);
        }

    }



    public class Rectangle 
    {

        double h, w;
        public Rectangle(double height, double width)
        {
            w = width;
            h = height;
        }

        public double getArea()
        {
            return Math.Ceiling(w * h);
        }

    }


    public class Square 
    {

        double w;
        public Square(double width)
        {
            w = width;
        }

        public double getArea()
        {
            return Math.Ceiling(w *w);
        }

    }

}
