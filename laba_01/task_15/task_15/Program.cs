using System.Globalization;
using System.Net.Http.Headers;

namespace task_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            float b = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            float c = float.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            int product = 0;
            if (a < 0) product++;
            if (c < 0) product++;
            if (b < 0) product++;

            if (product == 1 || product == 3)
            {
                Console.WriteLine("-");
            }
            else if (product == 0 || product == 2)
            {
                Console.WriteLine("+");
            }
        }
    }
}
