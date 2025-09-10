using System.Globalization;

namespace task_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a, b, h;
            float area;
            Console.WriteLine("Enter = a ");
            a = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            Console.WriteLine("Enter = b ");
            b = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            Console.WriteLine("Enter = h ");
            h = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    
            area = ((a + b) / 2f) * h;

            Console.WriteLine($"Area = {area}");
        }
    }
}
