namespace task_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);
            bool result = (n > 20)&&(n % 2 != 0);
            Console.WriteLine(result);
           

        }
    }
}
