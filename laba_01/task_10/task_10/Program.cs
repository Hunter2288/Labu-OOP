namespace task_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int lastDigit;

            Console.WriteLine("Enter n = ");
            n = int.Parse(Console.ReadLine()!);

            lastDigit = n % 10;

            Console.WriteLine($"lastDigit = {lastDigit}");
        }
    }
}
