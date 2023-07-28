using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberQuiz.Utilities
{
    public static class Number
    {
        /// <summary>
        /// Returns a random number in the range from 1 to 100.
        /// </summary>
        /// <returns></returns>
        public static int GetNumber()
        {
            var random = new Random();
            return random.Next(1, 100);
        }
    }
}
