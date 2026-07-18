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
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select any choice of your program to execute:\n1. String Programs\n2. Miscellaneous Programs");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            #region String Programs

                            Console.Write("Enter a word or a statement: ");
                            string userInput = Console.ReadLine();

                            if (string.IsNullOrEmpty(userInput))
                            {
                                Console.WriteLine("Please enter any word or statement");
                                Console.ReadKey();

                                break;
                            }

                            IStringProgram stringProgram = new StringProgram(userInput);
                            stringProgram.Print_First_Non_Repeating_Character().Wait();
                            stringProgram.Print_Lengthy_Word_from_given_Statement().Wait();
                            stringProgram.Print_Vowels_With_Count().Wait();
                            stringProgram.Print_Reverse_Words().Wait();
                            stringProgram.Print_Letters_Count().Wait();
                            #endregion

                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            #region Miscellaneous Programs

                            IMiscellaneousProgram miscellaneousProgram = new MiscellaneousProgram();

                            #region Printing the array elements after right shifting them by a given number of times

                            Console.Write("Enter a set of numbers separated by commas: ");
                            string userInput4 = Console.ReadLine();
                            if (string.IsNullOrEmpty(userInput4))
                            {
                                throw new Exception("Couldn't proceed with miscellaneous operations further with empty inputs!");
                            }
                            int[] numbersInput4 = userInput4.Split(',').Select(int.Parse).ToArray();
                            Console.Write("Enter the number of times to right shift: ");
                            int times = int.Parse(Console.ReadLine());
                            miscellaneousProgram.Right_Shift_and_Print_Array_elements(numbersInput4, times).Wait();

                            #endregion

                            #region Printing the array elements after removing duplicates

                            Console.Write("Enter a set of numbers separated by commas: ");
                            string userInput3 = Console.ReadLine();
                            if (string.IsNullOrEmpty(userInput3))
                            {
                                throw new Exception("Couldn't proceed with miscellaneous operations further with empty inputs!");
                            }
                            int[] numbersInput3 = userInput3.Split(',').Select(int.Parse).ToArray();
                            miscellaneousProgram.Remove_Duplicate_elements_in_an_Array(numbersInput3).Wait();

                            #endregion

                            #region Printing max negative number from the given set of numbers

                            Console.Write("Enter a set of numbers separated by commas: ");
                            string userInput1 = Console.ReadLine();
                            if (string.IsNullOrEmpty(userInput1))
                            {
                                throw new Exception("Couldn't proceed with miscellaneous operations further with empty inputs!");
                            }
                            double[] numbersInput1 = userInput1.Split(',').Select(double.Parse).ToArray();
                            miscellaneousProgram.Print_Max_Negated_Number(numbersInput1).Wait();
                            Console.ReadKey();

                            #endregion

                            #region Printing Nth largest number from the given set of numbers

                            Console.Write("Enter a set of numbers separated by commas: ");
                            string userInput2 = Console.ReadLine();
                            if (string.IsNullOrEmpty(userInput2))
                            {
                                throw new Exception("Couldn't proceed with miscellaneous operations further with empty inputs!");
                            }
                            double[] numbersInput2 = userInput2.Split(',').Select(double.Parse).ToArray();

                            Console.Write("Enter the value of index: ");
                            int n_th_Index = int.Parse(Console.ReadLine());
                            if ((n_th_Index >= 0) && (n_th_Index <= numbersInput2.Length))
                            {
                                miscellaneousProgram.Print_Nth_Largest_Number(numbersInput2, n_th_Index).Wait();
                            }
                            else
                            {
                                throw new Exception("Couldn't proceed with miscellaneous operations with invalid index!");
                            }

                            #endregion

                            #region Printing sum of all digits of a number until it's result is a single digit

                            Console.Write("Enter a number: ");
                            int numberInput = int.Parse(Console.ReadLine());
                            if (numberInput <= 0)
                            {
                                throw new Exception("Couldn't proceed with miscellaneous operations with invalid number input!");
                            }
                            miscellaneousProgram.Print_till_Sums_up_single_Digit(numberInput).Wait();

                            #endregion

                            #endregion

                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Console.ReadKey();
                }
                
                Console.Write("\nDo you want to continue? (y/n): ");
                string continueInput = Console.ReadLine();

                if (continueInput?.ToLower() != "y")
                {
                    break;
                }
            }
        }
    }
}
