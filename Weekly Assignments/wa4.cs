// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Weekly Assignment 4
// Submission Date:  06/10/2014
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
    static double ComputeBmi(double weight, double height)
    {
        return (weight / Math.Pow((height / 100), 2));
    }

	static void Main()
	{
            // Display program name and prompt for weight input to the user
            Console.WriteLine("-- Body Mass Index Calculator --");
            Console.Write("Enter your weight, in kg: ");

            // Get and convert the user's input weight to a double
            double weight = Convert.ToDouble(Console.ReadLine());

            // Display prompt for height input to the user
            Console.Write("Enter your height, in cm: ");

            // Get and convert the user's input height to a double
            double height = Convert.ToDouble(Console.ReadLine());

            // Calculate BMI from given values
            double bmi = ComputeBmi(weight, height);

            // Print the output to the console
            Console.WriteLine("Your body mass index is: {0:F2}", bmi);
	}
}