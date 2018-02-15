using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetStringName;
namespace nowa
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
