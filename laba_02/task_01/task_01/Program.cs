namespace task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = {  "cschrap", "sql", "html", "css", "js", "php", "java" };
            string[] arr2 = {  "js", "softuni", "nakov", "java", "learn", "php", "java" };
            int start = 0;
            int end = 0;

            int minLenth = Math.Min(arr1.Length, arr2.Length);
            for(int i = 0; i < minLenth; i++)
            {
                if (arr1[i] == arr2[i])
                {
                    start++;
                }
                else
                {
                    break;
                }
            }

            for(int i= 0; i < minLenth; i++)
            {
                if (arr1[minLenth - i - 1] == arr2[minLenth - i -1])
                {
                    end++;
                }
                else
                {
                    break;
                }
            }

            int maxSame = Math.Max(end, start);
            Console.WriteLine(maxSame);
            if(maxSame == start)
            {
                for(int i = 0; i < maxSame; i++)
                {
                    Console.WriteLine(arr1[i]);
                }
            }else
            {
                for(int i = 0; i< maxSame; i++)
                {
                    Console.WriteLine(arr1[minLenth - i - 1]);
                }
            }
        }
    }
}
