// -------------------------------------------------------------------	
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Weekly Assignment 7
// Submission Date:  11/11/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;

class Angle
{
    private double radians;

    public double Radians
    {
        get { return this.radians; }
        set { this.radians = value; }
    }

    public double Degrees
    {
		get { return this.radians * (180 / Math.PI); }
        set { this.radians = value * (Math.PI / 180); }
    }

    public double Sin { get { return Math.Sin(this.radians); } }
    public double Cos { get { return Math.Cos(this.radians); } }
    public double Tan { get { return Math.Tan(this.radians); } }

    public override string ToString()
    {
        return string.Format("{0} ({1}\u00b0)", this.radians, this.Degrees);
    }
}

static class Program
{
    private static void Main()
    {
        Angle a = new Angle();
        a.Degrees = 30.0;

        Console.WriteLine();
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("a.Radians = {0}", a.Radians);
        Console.WriteLine("a.Degrees = {0}", a.Degrees);
        Console.WriteLine("a.Sin = {0}", a.Sin);
        Console.WriteLine("a.Cos = {0}", a.Cos);
        Console.WriteLine("a.Tan = {0}", a.Tan);
    }
}
