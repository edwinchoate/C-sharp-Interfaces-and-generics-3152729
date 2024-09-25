namespace IntfChallenge;

class Program
{
    const string exitCommand = "exit";

    static void Main(string[] args)
    {
        Randomizer randomizer = new Randomizer();

        string input = "";
        
        while (input != exitCommand) 
        {
            Console.WriteLine("Enter the number for an upper bound:");
            input = Console.ReadLine() ?? "";

            if (input == exitCommand) break;

            int n;
            Int32.TryParse(input, out n);

            Console.WriteLine("Random number between 0 and {0}: {1}", n, randomizer.GetRandomNum(n));
        }

    }
}
