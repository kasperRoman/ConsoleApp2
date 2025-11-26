namespace ShowTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a number ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("enter a number ");
                    continue;
                }
                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                for (int i = 1; i <= 10; i++)
                {
                    int result = number * i;
                    Console.WriteLine($"{number} x {i} = {result}");
                }
                break;
            }
        }
    }
}
