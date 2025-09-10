namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            float average;

            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter a = {a} , b = {b} , c = {c} ");

            Console.WriteLine($"{a} , {b} , {c}");

            average = (a + b + c) / 3f;

            Console.WriteLine($" Average = {average:f5}");
        }
    }
}