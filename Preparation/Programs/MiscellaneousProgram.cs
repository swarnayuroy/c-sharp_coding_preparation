using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programs
{
    public interface IMiscellaneousProgram
    {
        Task Remove_Duplicate_elements_in_an_Array(int[] numbers);
        Task Print_till_Sums_up_single_Digit(int number);
        Task Print_Nth_Largest_Number(double[] numbers, int n_th_Index);
        Task Print_Max_Negated_Number(double[] numbers);
        Task Right_Shift_and_Print_Array_elements(int[] numbers, int times);
    }

    public class MiscellaneousProgram : IMiscellaneousProgram, IPrintService
    {
        #region Print Result
        public Task PrintResult(object data, string message)
        {
            string result = "";
            if (data is int[] numbers)
            {
                result = string.Join(", ", numbers);
            }
            else
            {
                result = data.ToString();
            }
            Console.WriteLine($"{message}{result}\n");
            return Task.CompletedTask;
        }
        #endregion

        public Task Print_Max_Negated_Number(double[] numbers)
        {
            if (numbers.Length > 1)
            {
                int foundNegatedNumberFlag = 0;
                for (int maxNegatedNumberIndex = 0; maxNegatedNumberIndex < numbers.Length; maxNegatedNumberIndex++)
                {
                    if (numbers[maxNegatedNumberIndex] < 0)
                    {
                        foundNegatedNumberFlag = 1;
                        double maxNegatedNumber = numbers[maxNegatedNumberIndex];
                        if (maxNegatedNumberIndex != (numbers.Length - 1))
                        {
                            for (int currentIndex = maxNegatedNumberIndex + 1; currentIndex < numbers.Length; currentIndex++)
                            {
                                if ((numbers[currentIndex] < 0) && (maxNegatedNumber < numbers[currentIndex]))
                                {
                                    maxNegatedNumber = numbers[currentIndex];
                                }
                            }
                        }
                        PrintResult(
                            maxNegatedNumber, 
                            $"Max negated number in the given set [{string.Join(", ", numbers)}] is: "
                        );
                        break;
                    }
                }
                if (foundNegatedNumberFlag == 0)
                {
                    Console.WriteLine($"Didn't find any negated numbers in the given set: [{string.Join(", ", numbers)}]");
                }
            }
            else
            {
                Console.WriteLine("We didn't find any number set to perform the operation.");
            }
            return Task.CompletedTask;
        }

        public Task Print_Nth_Largest_Number(double[] numbers, int n_th_Index)
        {
            if (numbers.Length > 1)
            {
                if ((n_th_Index >= 0) && (n_th_Index <= numbers.Length))
                {
                    double[] sortedNumbers = (from number in numbers orderby number descending select number).ToArray<double>();
                    PrintResult(
                        sortedNumbers[n_th_Index - 1],
                        $"The {n_th_Index}th largest number in the given set [{string.Join(", ", numbers)}] is: "
                    );
                }
                else
                {
                    Console.WriteLine($"The given index {n_th_Index} is out of range for the given set of numbers [{string.Join(", ", numbers)}]");
                }
            }
            else
            {
                Console.WriteLine("We didn't find any number set to perform the operation.");
            }
            return Task.CompletedTask;
        }

        public Task Print_till_Sums_up_single_Digit(int number)
        {
            if (number > 0)
            {
                int digitSum = 0;
                while (number != 0)
                {
                    digitSum += Convert.ToInt16(number % 10);
                    number = number / 10;
                }

                return digitSum.ToString().Length == 1 ? PrintResult(
                                                            digitSum, 
                                                            $"The single-digit sum for the given number is: "
                                                         ) 
                                                       : Print_till_Sums_up_single_Digit(digitSum);
            }
            else
            {
                Console.WriteLine("Please enter at least a double digit positive number");
            }
            return Task.CompletedTask;
        }

        public Task Remove_Duplicate_elements_in_an_Array(int[] numbers)
        {
            if (numbers.Length > 1)
            {
                int[] distinctNumbers = numbers.Distinct().ToArray<int>();
                PrintResult(
                    distinctNumbers, 
                    $"The distinct elements in the given set [{string.Join(", ", numbers)}] are: "
                );
            }
            else
            {
                Console.WriteLine("We didn't find any number set to perform the operation.");
            }
            return Task.CompletedTask;
        }

        public Task Right_Shift_and_Print_Array_elements(int[] numbers, int times)
        {
            if (numbers.Length > 1)
            {
                for (int step = 1; step <= times; step++)
                {
                    int number = numbers[0];
                    for (int i = 1; i < numbers.Length; i++)
                    {
                        int temp = numbers[i];
                        numbers[i] = number;
                        number = temp;
                    }
                    numbers[0] = number;
                }
                PrintResult(
                    numbers,
                    $"The result after right-shifting elements {times} times is: "
                );
            }
            else
            {
                Console.WriteLine("We didn't find any number set to perform the operation.");
            }
            return Task.CompletedTask;
        }
    }
}
