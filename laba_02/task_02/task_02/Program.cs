namespace task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n: ");
            int n = int.Parse(Console.ReadLine()!);
            int[] arr = new int[n];
            Console.WriteLine("Enter arr: ");
            ;
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine()!); 
            }
            Console.WriteLine("Enter k: ");
            int[] rotated = new int [n];
            int[] pluse = new int[n];
            int k = int.Parse(Console.ReadLine()!);
            
            for (int i = 0; i < n; i++)
            {
                rotated[i] = arr[i];
            }

            for (int l = 1; l <= k; l++)
            {
                int last = rotated[n - 1]; 
                for(int i = n - 1; i > 0; i--)
                {
                    rotated[i] = rotated[i - 1];
                }
                rotated[0] = last;

                for(int i = 0; i < n; i++)
                {
                    pluse[i] += rotated[i];
                }
                Console.WriteLine("Arr pluse: ");
                for(int i = 0; i< n; i++)
                {
                    Console.WriteLine(pluse[i]);
                }
            }
        }
    }
}
