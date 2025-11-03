using System;

namespace Untitled-1
{
    internal static class Program
    {
        /// <summary>
        /// Program entry point. Reads a number from the console, computes the sum of its base digits,
        /// and prints the result. After each run the user is asked whether to continue.
        /// </summary>
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a number: ");
                var input = Console.ReadLine() ?? string.Empty;

                try
                {
                    int sum = SumOfDigits(input);
                    Console.WriteLine($"Sum of digits: {sum}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.Write("Do you want to run again? (y/n): ");
                var response = (Console.ReadLine() ?? string.Empty).Trim();
                if (!response.Equals("y", StringComparison.OrdinalIgnoreCase) &&
                    !response.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    // Terminate the process so the console window closes automatically.
                    Environment.Exit(0);
                }

                Console.WriteLine(); // blank line before next iteration
            }
        }

        /// <summary>
        /// Returns the sum of all digit characters found in the input string.
        /// Non-digit characters (such as sign or decimal separator) are ignored.
        /// Throws <see cref="ArgumentException"/> if no digits are present.
        /// </summary>
        /// <param name="input">A string representation of the number (may contain sign/decimal).</param>
        /// <returns>Sum of the decimal digits.</returns>
        public static int SumOfDigits(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input is empty.");

            int sum = 0;
            bool foundDigit = false;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    foundDigit = true;
                    sum += c - '0';
                }
            }

            if (!foundDigit)
                throw new ArgumentException("Input contains no digits.");

            return sum;
        }

        // Optional helper overload: accepts a long value.
        public static int SumOfDigits(long value) =>
            SumOfDigits(value.ToString());
    }
}
