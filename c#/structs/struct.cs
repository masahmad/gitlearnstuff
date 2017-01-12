class Program
{
    static void Main(string[] args)
    {
        Car car;
        car = new Car("Blue");
        Console.WriteLine(car.Describe());
        car = new Car("Red");
        Console.WriteLine(car.Describe());
        Console.ReadKey();
    }
}
struct Car
{
    private string color;
    public Car(string color)
    {
        this.color = color;
    }
    public string Describe()
    {
        return "This car is " + Color;
    }
    public string Color
    {
        get { return color; }
        set { color = value; }
    }
}