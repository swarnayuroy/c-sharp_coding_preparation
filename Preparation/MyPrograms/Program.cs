using Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.Clear();

                #region String Program
                Console.Write("Enter a word or a statement: ");
                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput)) 
                {
                    Console.WriteLine("Please enter any word or statement");
                    Console.ReadKey();
                    
                    continue;
                }
                
                IStringProgram stringProgram = new StringProgram(userInput);
                stringProgram.Print_First_Non_Repeating_Character().Wait();
                stringProgram.Print_Lengthy_Word_from_given_Statement().Wait();
                stringProgram.Print_Vowels_With_Count().Wait();
                stringProgram.Print_Reverse_Words().Wait();
                stringProgram.Print_Letters_Count().Wait();
                #endregion

                Console.ReadKey();
                Console.Write("Do you want to continue? (y/n): ");
                string continueInput = Console.ReadLine();

                if (continueInput?.ToLower() != "y")
                {
                    break;
                }
            }            
        }
    }
}
