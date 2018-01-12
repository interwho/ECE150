// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Weekly Assignment 2
// Submission Date:  16/09/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;

// Calculates and displays the BMI of a person
class BmiCalc
{
	static void Main()
	{
            // Display program name and prompt for weight input to the user
            Console.WriteLine("Body Mass Index Calculator");
            Console.Write("Enter a weight (in kg): ");

            // Get and convert the user's input weight to a double
            double weight = Convert.ToDouble(Console.ReadLine());

            // Display prompt for height input to the user
            Console.Write("Enter a height (in cm): ");

            // Get and convert the user's input height to a double
            double height = Convert.ToDouble(Console.ReadLine());

            // Calculate BMI from given values
            double bmi = weight / Math.Pow((height / 100), 2);

            // Print the output to the console
            Console.WriteLine("Resulting body mass index: {0:F2}", bmi);
	}
}