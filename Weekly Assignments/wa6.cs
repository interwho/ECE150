// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Weekly Assignment 6
// Submission Date:  04/11/2014
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
    const string innovateFile = "StrategicPlan.txt";
    
    static void Main( )
    {
        StreamReader sr = new StreamReader(innovateFile);
            int ino = 0;
            int ent = 0;
            bool longline = true;
            int numlines = 0;
            int greatest = 0;
            string line = sr.ReadLine( );
            while (line != null)
            {
                if (line.Contains("innova"))
                {
                    ino = ino + 1;
                    longline = false;
                }
                if (line.Contains("entrepre"))
                {
                    ent = ent + 1;
                    longline = false;
                }
                if (longline == true)
                {
                    numlines = numlines + 1;
                }
                else
                {
                    if (greatest < numlines)
                    {
                        greatest = numlines;
                        numlines = 0;
                    }
                }
                longline = true;
                line = sr.ReadLine();
            }
            
        Console.WriteLine( "Number of lines with innova: {0}", ino );
        Console.WriteLine( "Number of lines with entrepre: {0}", ent );
        Console.WriteLine( "Greatest buzzword-free range: {0}", greatest );
    }
}