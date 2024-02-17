using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// Calculates the total calories of a meal based on selected items.
        /// </summary>
        /// <param name="burger">Index representing the chosen burger.</param>
        /// <param name="drink">Index representing the chosen drink.</param>
        /// <param name="side">Index representing the chosen side order.</param>
        /// <param name="dessert">Index representing the chosen dessert.</param>
        /// <returns>Total calorie count or an error message</returns>
        /// <example>
        ///     GET ../api/J1/Menu/4/4/4/4 -> Your total calorie count is 0
        /// </example>
        /// <example>
        ///     GET ../api/J1/Menu/1/2/3/4 -> Your total calorie count is 691
        /// </example>
        /// <example>
        ///     GET ../api/J1/Menu/0/2/3/4 -> Invalid item selection
        /// </example>
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            // Initialization of calories array of each items
            int [] burgerCaloriesArray = new int[] { 461, 431, 420, 0 };
            int [] drinkCaloriesArray = new int[] { 130, 160, 118, 0 };
            int [] sideCaloriesArray = new int[] { 100, 57, 70, 0 };
            int [] dessertCaloriesArray = new int[] { 167, 266, 75, 0 };

            // Calculate character index based on each items as array index starts from 0
            int burgerIndex = burger - 1;
            int drinkIndex = drink - 1;
            int sideIndex = side - 1;
            int dessertIndex = dessert - 1;

            // Check if any selected index is out of range
            if (burgerIndex < 0 || burgerIndex >= burgerCaloriesArray.Count() ||
                drinkIndex < 0 || drinkIndex >= drinkCaloriesArray.Count() ||
                sideIndex < 0 || sideIndex >= sideCaloriesArray.Count() ||
                dessertIndex < 0 || dessertIndex >= dessertCaloriesArray.Count())
            {
                // Return an error message
                return "Invalid item selection";
            }

            // Calculate total calories of the meal
            int totalCalories = burgerCaloriesArray[burgerIndex] + drinkCaloriesArray[drinkIndex] + sideCaloriesArray[sideIndex] + dessertCaloriesArray[dessertIndex];

            // Return total caroies count message
            return "Your total calorie count is " + totalCalories;
        }

        
    }
}
