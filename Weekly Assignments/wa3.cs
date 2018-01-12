// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Weekly Assignment 3
// Submission Date:  25/09/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;

// Calculates and displays the A091733 pattern
class A091733
{
	static void Main()
	{
            // Display program name and prompt for weight input to the user
            Console.WriteLine(String.Format("{0,8} {1,8}", "n", "a(n)"));
            //Loop the program for the required output (from 10001-10025)
            for (long n = 10001; n <= 10025; n++)
            {
                //Initialize m
                long m = 2;

                // While the statement is not equal to zero, repeat the loop
                while(((Math.Pow(m, 3) - 1) % n) != 0)
                {
                    // Increment m by one
                    m = m + 1;
                }
                // Print the output to the console
                Console.WriteLine(String.Format("{0,8:n0} {1,8:n0}", n, m));
            }
	}
}