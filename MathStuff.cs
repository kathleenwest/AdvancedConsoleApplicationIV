using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedConsoleApplicationIV
{
    /// <summary>
    /// This class offers math functions to calculate
    /// prime numbers
    /// </summary>
	public static class MathStuff
	{
		/// <summary>
		/// Determines the approximate number of primes less than the given number
		/// </summary>
		/// <param name="x">Number to approximate number of primes below it</param>
		/// <returns>Approximate number of primes</returns>
		public static ulong ApproximateNumberOfPrimes(ulong x)
		{
            // x / (ln x - 1)
            // add an additional “fudge-factor” of 5% to the result

            double num = ((double)x / (Math.Log((double)x, Math.E) - 1)) * 1.05;

            return (ulong)num;

		} // end of method


		/// <summary>
		/// Brute force algorithm to determine if a number is prime
		/// </summary>
		/// <param name="number">Number to test</param>
		/// <returns>true if prime, false otherwise</returns>
		public static bool IsPrime(ulong number)
		{
            if (number <= 1)
            {
                return false;     
            }

            if (number == 2 || number == 3 || number == 5)
            {
                return true;
            }

            // Check for even numbers
            if ((number & 1) == 0) return false; // First bit not set indicates even

            // Check for numbers divisible by 5
            if (number % 5 == 0)
            {
                // Any multiple of 5 (except 5) is not prime
                return false;
            }

            // If n is a positive composite integer, then n has a prime divisor less than or equal to sqrt(n)
            ulong max = (uint)Math.Sqrt(number);
            int counter = 3;

            // all prime numbers must end with 1, 3, 7 or 9
            for (ulong i = 3; i <= max; i += 2)
            {
                // We are using counter to monitor when
                // we are testing for multiples of 5.
                // When it is equal to 4, reset it to 0 and skip to the next iteration.
                if (counter == 4)
                {
                    counter = 0;
                    continue;
                }
                counter++;

                // If the remainder of number divided by i is not 0, then number cannot be
                // prime as it has a whole factor
                if (number % i == 0)
                {
                    // Found a factor, not prime
                    return false;
                }

            } // end of for loop

           // Found a Prime
           return true;

		} // end of method

	} // end of class
} // end of namespace
