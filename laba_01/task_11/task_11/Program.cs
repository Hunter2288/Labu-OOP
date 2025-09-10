namespace task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number, n, ndigit;
            Console.WriteLine("Enter n = ");
            n = int.Parse(Console.ReadLine()!);
            Console.WriteLine("enter number = ");
            number = int.Parse(Console.ReadLine()!);

            if (n > number.ToString().Length)
            {
                Console.WriteLine("-");
            }
            else
            {
                ndigit = number / (int)Math.Pow(10, n - 1) % 10;
                Console.WriteLine(ndigit);
            }
        }
    }
}
