// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Weekly Assignment 5
// Submission Date:  28/10/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;
using System.IO;

static class Program
{
    const string intensityFile = "WorldCupIllumination.csv";

    // Return minimum and maximum values
    static void FindMinMax(int[][] intensities, out int min, out int max)
    {
        //set initial variable values
        min = intensities[0][0];
        max = intensities[0][0];

        //go through 1st dimension of array to get 2nd dimension
        foreach (int[] i in intensities)
        {
            //go through second dimension of array to get intensities
            foreach (int y in i)
            {
                //test for maximum
                if (y > max)
                {
                    max = y;
                }
                //test for minimum
                if (y < min)
                {
                    min = y;
                }
            }
        }
    }
    
    static void Main( )
    {
        int[ ][ ] intensities;
        
        // Read the array of intensities from the file.
        using( StreamReader sr = new StreamReader( intensityFile ) )
        {
            int rows = int.Parse( sr.ReadLine( ) );
            int cols = int.Parse( sr.ReadLine( ) );
            
            intensities = new int[ rows ][ ];
            for( int row = 0; row < rows; row ++ )
            {
                intensities[ row ] = new int[ cols ];
                string[ ] words = sr.ReadLine( ).Split( ",".ToCharArray( ) );
                for( int col = 0; col < cols; col ++ )
                {
                    intensities[ row ][ col ] = int.Parse( words[ col ] );
                }
            }
        }
            
        // Find minimal and maximal intensities.
        int minIntensity;
        int maxIntensity;
        
        FindMinMax( intensities, out minIntensity, out maxIntensity );
        
        Console.WriteLine( );
        Console.WriteLine( "minimal intensity = {0}", minIntensity );
        Console.WriteLine( "maximal intensity = {0}", maxIntensity );
    }
}