using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGLGame
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string ad1 = Read("Adjective 1: ");
                string ad2 = Read("Adjective 2: ");
                string ad3 = Read("Adjective 3: ");

                string no1 = Read("Noun 1: ");
                string no2 = Read("Noun 2: ");

                PrintMadLibs(ad1, ad2, ad3, no1, no2);
                Console.WriteLine("\nPress any key to restart...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static string Read(string s)
        {
            Console.Write(s);
            return Console.ReadLine();
        }

        static void PrintMadLibs(string a1, string a2, string a3, string n1, string n2)
        {
            string[] vowels = { "a", "e", "i", "o", "u", "y" };

            string last = a3[0].ToString().ToLower();

            string ending = "y";

            if (vowels.Contains(last))
            {
                if (last != "y" || (last == "y" && a3.Length > 2 && vowels.Contains(a3[1].ToString().ToLower())))
                {
                    ending = "ine";
                }
            }

            Console.WriteLine("\nHello World, thou " + a1 + " world!");
            Console.WriteLine("I beseech thee, thou " + a2 + " " + n1 + ", to let me into th" + ending + " " + a3 + " " + n2 + "!");
        }
    }
}
