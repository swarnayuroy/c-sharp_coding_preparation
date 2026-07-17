using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programs
{
    public interface IStringProgram 
    {
        Task Print_Lengthy_Word_from_given_Statement();
        Task Print_First_Non_Repeating_Character();
        Task Print_Vowels_With_Count();
        Task Print_Reverse_Words();
        Task Print_Letters_Count();
    }
    public class StringProgram : IStringProgram, IPrintService
    {
        private readonly string _userInput;
        private readonly string[] _words;
        public StringProgram(string inputString)
        {
            this._userInput = inputString;
            this._words = !string.IsNullOrEmpty(_userInput) ? 
                (from word in _userInput.Split(' ') select word.ToLower().Trim()).ToArray<string>() 
                : new string[] { };
        }

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

        public Task Print_Reverse_Words()
        {
            if (_words.Count() > 0)
            {
                string reversedResult = "";
                foreach (string word in _words)
                {
                    string reverseWord = "";
                    for (int i = word.Length - 1; i >= 0; i--)
                    {
                        reverseWord += word[i];
                    }
                    reversedResult += reverseWord + " ";
                }
                PrintResult(reversedResult.Trim(), $"Reversed words of '{_userInput}' is: ");
            }
            else
            {
                Console.WriteLine("Oops! couldn't perform operation on empty string.");
            }
            return Task.CompletedTask;
        }
        
        public Task Print_First_Non_Repeating_Character()
        {
            if (_words.Count() > 0)
            {
                List<string> result = new List<string>();
                foreach (string word in _words)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        char letter = word[i];
                        if (word.Count(c => c == letter) == 1)
                        {
                            result.Add(letter.ToString());
                            break;
                        }
                    }
                }
                PrintResult(result, $"1st non-repeating character of words in '{_userInput}' are: ");
            }
            else
            {
                Console.WriteLine("Oops! couldn't perform operation on empty string.");
            }
            return Task.CompletedTask;
        }

        public Task Print_Lengthy_Word_from_given_Statement()
        {
            if (_words.Count() > 0) 
            {
                string result = (from word in _words orderby word.Length descending select word).FirstOrDefault<string>();
                PrintResult(result, $"Lengthy word from the statement '{_userInput}' is: ");
            }
            else
            {
                Console.WriteLine("Oops! couldn't perform operation on empty string.");
            }
            return Task.CompletedTask;
        }

        public Task Print_Vowels_With_Count()
        {
            if (_words.Count() > 0)
            {
                char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
                Dictionary<char, int> vowelCount = new Dictionary<char, int>();
                foreach (string word in _words) {
                    foreach (char letter in word) {
                        if (vowels.Contains(letter)) {
                            if (vowelCount.ContainsKey(letter))
                            {
                                vowelCount[letter] = ++vowelCount[letter];
                            }
                            else
                            {
                                vowelCount[letter] = 1;
                            }
                        }
                    }
                }
                PrintResult(vowelCount, $"Vowels count in '{_userInput}' are: ");
            }
            else
            {
                Console.WriteLine("Oops! couldn't perform operation on empty string.");
            }
            return Task.CompletedTask;
        }

        public Task Print_Letters_Count()
        {
            if (_words.Count() > 0)
            {
                Dictionary<char, int> lettersCount = new Dictionary<char, int>();
                foreach (string word in _words)
                {
                    foreach (char letter in word)
                    {
                        if (lettersCount.ContainsKey(letter))
                        {
                            lettersCount[letter] = ++lettersCount[letter];
                        }
                        else
                        {
                            lettersCount[letter] = 1;
                        }
                    }
                }
                PrintResult(lettersCount, $"Letters count in '{_userInput}' are: ");
            }
            else
            {
                Console.WriteLine("Oops! couldn't perform operation on empty string.");
            }
            return Task.CompletedTask;
        }
    }
}
