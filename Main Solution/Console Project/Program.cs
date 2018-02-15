using System;
using GetStringName;

namespace Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name: ");
            
            GetString imie = new GetString();
            Console.WriteLine(imie);
            Console.ReadLine();

            
        }
    }
}
