// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Programming Assignment 2
// Submission Date:  29/09/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;

// Calculates and displays the binary number conversion of an unsigned integer
class BinaryConverter
{
	static void Main()
	{
            // Initialize counter, quotient, and input variables
            int i, x;
            uint n, dec;

            // Display program name and prompt to the user
            Console.WriteLine("Binary encoder\n");
            Console.Write("Enter an unsigned integer number: ");

            // Get and try to convert the user's input to an unsigned integer
            if (!(UInt32.TryParse(Console.ReadLine(), out dec)))
            {
                // If the input is invalid, print error message and exit
                Console.Write("ERROR: Input is not a valid unsigned integer!");
                Environment.Exit(0);
            }

            // Print the start of the output to the console
            Console.Write("The binary encoding of {0} is ", dec);

            // Convert the number
            if (dec == 0)
            {
                // When the number entered is zero, simply print 32 zeros
                for (i = 1; i <= 32; i++)
                {
                    Console.Write("0");
                }
            }
            else
            {
                // Output the correct amount of padding zeros by subtracting
                // # of digits in result from 32.
                for (i = 1; i < (32 - Math.Ceiling(Math.Log(dec, 2))); i++)
                {
                    Console.Write("0");
                }
                // Get number of digits in result
                int y = Convert.ToInt32(Math.Ceiling(Math.Log(dec, 2)));
                // For each digit in the result, print digits in reverse
                for (i = 0; i <= Math.Ceiling(Math.Log(dec, 2)); i++)
                {
                    // Reinitialize input variable (required to reverse)
                    n = dec;
                    // Calculate n/2 for the current digit iteration
                    for (x = 1; x <= y; x++)
                    {
                        // Divide n/2 required # of times to get current digit
                        n = n / 2;
                    }
                    // Go on to the next digit
                    y = y - 1;
                    // Print the remainder of the current digit
                    // (binary representation)
                    Console.Write(n % 2);
                }
            }
	}
}
