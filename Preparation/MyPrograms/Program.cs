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
                Console.WriteLine("Select any choice of your program to execute:\n1. String Programs\n2. Miscellaneous String Programs\n3. Miscellaneous Programs\n4. LINQ Programs");
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
                            #region Miscellaneous String Programs
                            IMiscellaneousStringProgram miscellaneousStringProgram = new MiscellaneousStringProgram();

                            #region Replace Letter with Special Character in a given string

                            Console.Write("Enter a statement: ");
                            string statement = Console.ReadLine();
                            if (string.IsNullOrEmpty(statement))
                            {
                                throw new Exception("Statement cannot be empty!");
                            }
                            Console.Write("Enter any letter from the statement to replace with special character('$', '#', '@') comma separated: ");
                            string letter_and_character_Input = Console.ReadLine();
                            if (string.IsNullOrEmpty(letter_and_character_Input))
                            {
                                throw new Exception("Letter and special character input cannot be empty!");
                            }
                            char[] charInput = letter_and_character_Input.Split(',').Select(char.Parse).ToArray();

                            miscellaneousStringProgram.Replace_Letter_with_Special_Character(statement, charInput[0], charInput.Length > 1 ? charInput[1] : '$').Wait();
                            #endregion

                            #region Reorder given String by Prefixed Number

                            miscellaneousStringProgram.Reorder_given_String_by_Prefixed_Number().Wait();

                            #endregion

                            #endregion

                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            #region Miscellaneous Programs

                            IMiscellaneousProgram miscellaneousProgram = new MiscellaneousProgram();

                            #region Printing the pairs of numbers that sums up to a given target value

                            Console.Write("Enter a set of numbers separated by commas: "); 
                            string userInput5 = Console.ReadLine(); 
                            if (string.IsNullOrEmpty(userInput5))
                            {
                                throw new Exception("Couldn't proceed with miscellaneous operations further with empty inputs!");
                            }
                            int[] numbersInput5 = userInput5.Split(',').Select(int.Parse).ToArray();
                            Console.Write("Enter the target value: ");
                            int targetValue = int.Parse(Console.ReadLine());

                            miscellaneousProgram.Print_Pairs_that_sums_up_Target_Value(numbersInput5, targetValue).Wait();

                            #endregion

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
                        case 4:
                            Console.Clear();
                            #region LINQ Programs
                            ILINQ_Program linqProgram = new LINQ_Program();

                            #region Listing Details
                            linqProgram.Print_Employee_Details().Wait();
                            linqProgram.Print_Department_Details().Wait();
                            linqProgram.Print_Insurance_Details().Wait();
                            #endregion

                            linqProgram.Print_Employee_Department_Insurance_Details().Wait();
                            linqProgram.Print_Employees_with_or_without_Department().Wait();
                            linqProgram.Print_Employees_in_each_Department_Details().Wait();

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
