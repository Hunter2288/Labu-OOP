namespace task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine()!);
            int[] arr = new int[4 * k];

            Console.WriteLine("arr:");
            for (int i = 0; i < 4 * k; i++)
            {
                arr[i] = int.Parse(Console.ReadLine()!);
            }

            // start 
            int[] start = new int[k];
            for (int i = 0; i < k; i++)
            {
                start[i] = arr[k-1-i];
            }
            Console.WriteLine("Start:");
            foreach (int num in start) Console.WriteLine(num);

            // middle 
            int[] middle = new int[2 * k];
            for (int i = 0; i < 2 * k; i++)
            {
                middle[i] = arr[k+i];
            }
            Console.WriteLine("Middle:");
            foreach (int num in middle) Console.WriteLine(num);

            // last 
            int[] last = new int[k];
            for (int i = 0; i < k; i++)
            {
                last[i] = arr[4 * k - 1 - i];
            }
            Console.WriteLine("Last:");
            foreach (int num in last) Console.WriteLine(num);
            // start + last
            int[] row1 = new int[2 * k];
            int j = 0;
            for(int i = 0; i < k; i++)
            {
                row1[i] = start[i];
            }
            for(int i = 0; i < k; i++)
            {
                row1[i + k] = last[i];
            }
            // pluse
            int[] pluse = new int[2 * k];
            for(int i = 0; i < k*2; i++)
            {
                pluse[i] = middle[i] + row1[i];
            }
            Console.WriteLine("Pluse:");
            foreach (int num in pluse) Console.WriteLine(num);
        }
    }
}
