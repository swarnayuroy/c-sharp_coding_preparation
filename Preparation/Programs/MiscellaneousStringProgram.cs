using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programs
{
    public interface IMiscellaneousStringProgram
    {
        Task Replace_Letter_with_Special_Character(string userInputString, char letter, char specialCharacter = '$');
        Task Reorder_given_String_by_Prefixed_Number(string defaultInput = "11|AA|ABC, 14|BB|QOP, 12|CC|WER");
    }

    public class MiscellaneousStringProgram : IMiscellaneousStringProgram, IPrintService
    {
        #region Print Result
        public Task PrintResult(object data, string message)
        {
            string result = "";
            if (data is List<string> list_of_stringData)
            {
                result = string.Join(", ", list_of_stringData);
            }
            else if (data is Dictionary<char, int> dataValue)
            {
                List<string> dataValueResult = new List<string>();
                foreach (var item in dataValue)
                {
                    dataValueResult.Add($"{item.Key.ToString()}{item.Value.ToString()}");
                }
                result = string.Join(", ", dataValueResult);
            }
            else
            {
                result = data.ToString();
            }
            Console.WriteLine($"{message}{result}\n");
            return Task.CompletedTask;
        }
        #endregion

        public Task Reorder_given_String_by_Prefixed_Number(string defaultInput = "11|AA|ABC, 14|BB|QOP, 12|CC|WER")
        {
            Console.WriteLine($"\nThe default input string is: {defaultInput}");
            var resultArr = (from item in defaultInput.Split(',') 
                             orderby Convert.ToInt16(item.Split('|')[0]) 
                             select item.Trim()).ToList<string>();
            
            PrintResult(
                resultArr,
                $"The reordered string by prefixed number is: "
            );

            return Task.CompletedTask;
        }

        public Task Replace_Letter_with_Special_Character(string userInputString, char letter, char specialCharacter = '$')
        {
            if (!string.IsNullOrEmpty(userInputString))
            {
                string resultString = "";
                int foundLetterFlag = 0;
                for (int i = 0; i < userInputString.Length; i++)
                {
                    if (userInputString[i] == letter)
                    {
                        foundLetterFlag = 1;
                        resultString += specialCharacter;
                    }
                    else
                    {
                        resultString += userInputString[i];
                    }
                }
                if (foundLetterFlag == 1)
                {
                    PrintResult(resultString, $"Result after replacing letter {letter} in the string {userInputString} is: ");
                }
                else
                {
                    Console.WriteLine($"Letter {letter} not found in the string {userInputString}.");
                }
            }
            else
            {
                Console.WriteLine("Oops! couldn't perform operation on empty string.");
            }
            return Task.CompletedTask;
        }
    }
}
