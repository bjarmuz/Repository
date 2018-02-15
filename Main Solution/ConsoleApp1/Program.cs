using GetStringName;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetString y = new GetString();
            string input = Console.ReadLine();
            int doubleInput;

            if (int.TryParse(input, out doubleInput))
            {
                y.Player(doubleInput);
            }
            else
            {
                y.Player(input);
            }
            Console.ReadLine();
        }
    }
}