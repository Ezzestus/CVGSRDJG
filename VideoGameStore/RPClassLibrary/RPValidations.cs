/* Filename: Validations.cs
 * Description: This class is responsible for providing validation methods.
 * 
 * Revision History:
 *     Ryan Pease, 2016-10-29: Created
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RPClassLibrary
{
    public class RPValidations
    {
        /// <summary>
        /// This method's purpose is to capitalize the first word of either a word, or a series of words to have each word capitalized.
        /// </summary>
        /// <param name="value">The string value to be capitalized</param>
        /// <param name="titleCase">Boolean value determines whether only the first word or every word is capitalized</param>
        /// <returns></returns>
        public static string Capitalize(string value, bool titleCase)
        {
            string newValue = "";                               // how to account for first names/last names with hyphen? should capitalize word after hyphen in name, but not in title
            if (value == null)
            {
                value = "";
            }
            else
            {
                if (titleCase)
                {
                    value = value.ToLower().Trim();
                    string[] words = value.Split(' ');
                    foreach (string word in words)
                    {
                        char[] values = word.ToCharArray();
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (i == 0)
                            {
                                newValue += Char.ToString(values[0]).ToUpper();
                            }
                            else
                            {
                                newValue += values[i];
                                if (i == values.Length -1)
                                {
                                    newValue += " ";
                                }
                            }
                        }
                    }
                }
                else
                {
                    value = value.ToLower().Trim();
                    char[] values = value.ToCharArray();                    
                    for (int i = 0; i < values.Length; i++)
                    {
                        if (i == 0)
                        {
                            newValue += Char.ToString(values[0]).ToUpper();
                        }
                        else
                        {
                            newValue += values[i];
                        }
                    }
                }               
                value = newValue.Trim();
            }
            return value;
        }

        public static string CapitalizeSentences(string value)
        {
            if (value == null)
            {
                value = "";
            }
            else
            {
                string newValue = "";
                string[] values = value.ToLower().Split('.');
                for (int i = 0; i < values.Length; i++)
                {
                    string[] words = values[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < words.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            if (j == (words.Length - 1))
                            {
                                newValue += Capitalize(words[j], false) + ".";
                            }
                            else
                            {
                                newValue += Capitalize(words[j], false) + " ";
                            }
                        }
                        else if (j == 0)
                        {
                            if (j == (words.Length - 1))
                            {
                                newValue += " " + Capitalize(words[j], false) + ".";
                            }
                            else
                            {
                                newValue += " " + Capitalize(words[j], false) + " ";
                            }
                        }
                        else if (j == (words.Length - 1))
                        {
                            newValue += words[j] + ".";
                        }
                        else
                        {
                            newValue += words[j] + " ";
                        }
                    }
                }
                value = newValue;
            }                        
            return value;
        }

        /// <summary>
        /// This method converts to uppercase and removes whitespace delimiters in postal code values
        /// </summary>
        /// <param name="value">the value to be formatted</param>
        /// <returns>the formatted value</returns>
        public static string FormatPostalCode(string value)
        {
            string newValue = "";
            if (string.IsNullOrWhiteSpace(value))
            {
                value = "";
            }
            value = value.ToUpper().Trim();
            string[] values = value.Split(' ');    
            foreach (string part in values)
            {
                for (int i = 0; i < part.Length; i++)
                {
                    newValue += part[i];
                }
            }            
            Regex pattern = new Regex(@"^([ABCEGHJKLMNPRSTVXY]\d[A-Z]\d[A-Z]\d)$");
            if (pattern.IsMatch(newValue))
            {
                value = newValue;
            }                        
            return value;
        }

        /// <summary>
        /// This method removes character delimiters from a phone number
        /// </summary>
        /// <param name="value">the value to be formatted</param>
        /// <returns>the formatted value</returns>
        public static string FormatPhoneNumber(string value)
        {
            string newValue = "";
            if (string.IsNullOrWhiteSpace(value))
            {
                value = "";
            }
            value = value.Trim();
            string[] values = value.Split('-');
            foreach (string part in values)
            {
                for (int i = 0; i < part.Length; i++)
                {
                    newValue += part[i];
                }
            }
            Regex pattern = new Regex(@"\d{10}");
            if (pattern.IsMatch(newValue))
            {
                value = newValue;
            }
            return value;
        } 
    }
}
