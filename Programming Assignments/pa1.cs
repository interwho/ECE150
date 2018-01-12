// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Programming Assignment 1
// Submission Date:  13/09/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;

// Calculates and displays the net weight of a package in kilograms
class WeightCalc
{
	static void Main()
	{
            // Initialize the variable for net weight
            double net;

            // Display program name and prompt to the user
            Console.WriteLine("Net Weight Calculator");
            Console.Write("Enter the gross weight in pounds: ");

            // Get and convert the user's input to a double
            double gross = Convert.ToDouble(Console.ReadLine());

            // Convert the input to kilograms
            double kilos = gross / 2.20462;

            // Convert the gross weight to net weight
            net = kilos * 0.85;

            // Set the value for net weight as 1.00 if less than 1.00
            if(net < 1.00)
            {
                net = 1.00;
            }

            // Print the output to the console
            Console.WriteLine("The net weight in kilograms is: {0,8:F3}", net);
	}
}
