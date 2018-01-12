// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Weekly Assignment 1
// Submission Date:  12/09/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;

// Calculates and displays the escape speed of an asteroid
class EscapeSpeed
{
	static void Main()
	{
        	// Declare variables used in calculation
        	double result, gravConst, radius, density;

        	// Set variable values as given in assignment
        	gravConst = 6.673 * Math.Pow(10.00, -11.00);
        	radius = 900.00;
        	density = 6000.00;

        	// Calculate escape speed
        	result = (8*Math.PI*gravConst*density*Math.Pow(radius, 2))/3;
        	result = Math.Sqrt(result);

        	// Print the output from the calculation
        	Console.WriteLine(result);
	}
}
