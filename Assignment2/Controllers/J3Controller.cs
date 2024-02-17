using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J3Controller : ApiController
    {
        /// <summary>
        /// Problem J3:Cell-Phone Messaging
        /// Calculates the typing time for a given word.
        /// </summary>
        /// <param name="word">The word for which to calculate typing time.</param>
        /// <returns>The typing time in seconds.</returns>
        /// <example>
        ///  GET ../api/J3/TypingTime/a -> 1
        /// </example>
        /// <example>
        ///  GET ../api/J3/TypingTime/dada -> 4
        /// </example>
        /// <example>
        ///  GET ../api/J3/TypingTime/bob -> 7
        /// </example>
        /// <example>
        ///  GET ../api/J3/TypingTime/abba -> 12
        /// </example>
        /// <example>
        ///  GET ../api/J3/TypingTime/cell -> 13
        /// </example>
        [HttpGet]
        [Route("api/J3/TypingTime/{word}")]
        public string TypingTime(string word)
        {
            // This will call a function to calculate typing time for the given word
            int typingTime = CalculateTypingTime(word);

            // The return type is of string so the result is converted to string and get returned
            return typingTime.ToString();
        }

        private int CalculateTypingTime(string word)
        {
            // Initiaalizing typing time to 0 and previous character a null value
            int typingTime = 0;
            char prevChar = '\0';

            // Iterating through each character in the given word
            foreach (char c in word)
            {
                // Added the number of key presses required for the current charcter
                typingTime += GetKeyPresses(c);

                // Added a pause of 2 if the current character is on the same key as the previous character
                // by calling the method AreConsecutiveCharactersOnSameKey and passing the previous and current character
                if (prevChar != '\0' && AreConsecutiveCharactersOnSameKey(prevChar, c))
                {
                    typingTime += 2;
                }

                // Upddating the previous character
                prevChar = c;
            }

            // This will return the typing time to the calling statement
            return typingTime;
        }

        private int GetKeyPresses(char c)
        {
            // Defining key mappings for the characters
            if ("adgjmptw".Contains(c))
            {
                return 1;
            }
            else if ("behknqux".Contains(c))
            {
                return 2;
            }
            else if ("cfilorvy".Contains(c))
            {
                return 3;
            }
            else if ("sz".Contains(c))
            {
                return 4;
            }
            else
            {
                // IF invalid character found then return 0
                return 0;
            }
        }

        private bool AreConsecutiveCharactersOnSameKey(char prevChar, char currentChar)
        {
            // A string array to define the key layouts for the consecutive characters
            string[] keys = { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

            // Loop to check if the characters are on the same key
            foreach (string key in keys)
            {
                if (key.Contains(prevChar) && key.Contains(currentChar))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
