using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// Determines how many ways the sum of 10 can be rolled with two dice.
        /// </summary>
        /// <param name="m">Number of sides on the first die.</param>
        /// <param name="n">Number of sides on the second die.</param>
        /// <returns>Response indicating the number of ways to get the sum 10 by rolling two die {m} and {n}.</returns>
        /// <example>
        ///  GET ../api/J2/DiceGame/6/8 -> There are 5 total ways to get the sum 10.   
        /// </example>
        /// <example>
        ///  GET ../api/J2/DiceGame/12/4 -> There are 4 total ways to get the sum 10.   
        /// </example>
        /// <example>
        ///  GET ../api/J2/DiceGame/3/3 -> There are 0 ways to get the sum 10.   
        /// </example>
        /// <example>
        ///  GET ../api/J2/DiceGame/5/5 -> There is 1 way to get the sum 10..   
        /// </example>

        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {
            // Initialize a counter to 0
            int count = 0;

            // Iterate through all possible combinations of dice rolls
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // Check if the sum is 10
                    if (i + j == 10)
                    {
                        count++;
                    }
                }
            }

            // Generate response message based on the count of ways
            if (count == 0) {
                return "There are 0 ways to get the sum 10.";
            } else if (count == 1)
            {
                return "There is 1 way to get the sum 10.";
            } else
            {
                return "There are " + count + " total ways to get the sum 10.";
            }                                      
        }
    }
}
