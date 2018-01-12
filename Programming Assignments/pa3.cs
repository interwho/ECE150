// -------------------------------------------------------------------
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Programming Assignment 3
// Submission Date:  14/11/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

// Class holds the sequence description of a protein.
class Protein
{
    string id;
    string name;
    string sequence;

    public Protein(string id, string name, string sequence)
    {
        this.id = id;
        this.name = name;
        this.sequence = sequence;
    }

    public string Id { get { return id; } }
    public string Name { get { return name; } }

    // Does the protein sequence contain a specified subsequence?
    public bool ContainsSubsequence(string sub)
    {
        //Handle null and blank subsequence strings by returning false
        if (sub == "" || sub == null)
        {
            return false;
        }
        
        // Return true
        // if this protein's sequence contains the substring passed
        // as a parameter, and false otherwise.
        if (this.sequence.Contains(sub))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // How often does a specified subsequence occur in the protein?
    public int CountSubsequence(string sub)
    {
        //Handle null and blank subsequence strings by returning 0
        if (sub == "" || sub == null)
        {
            return 0;
        }
        
        // Return the count
        // of the number of times the substring passed as a parameter
        // appears in this protein's sequence.
        string[] charsub = { sub };
        // Split string by the # of occurances, and return the # of parts-1
        return this.sequence.Split(charsub, StringSplitOptions.None).Length-1;
    }

    // Output a string showing only the location of a specified subsequence
    // in the sequence which specifies the protein.
    public string LocateSubsequence(string sub)
    {
        string locations;
        //Handle null and blank subsequence strings by returning 0
        if (sub == "" || sub == null)
        {
            locations = this.sequence.Replace(System.Environment.NewLine, "");
            return Regex.Replace(locations, "[^|]", ".");
        }
        // Return a string
        // the same length as this protein's sequence but with every 
        // character set to '.' except for places where the substring passed
        // as a parameter appears in this protein's sequence.
        string placeholders = null;
        // Create a placeholder variable with pipes
        for (int i = 0; i < sub.Length; i++)
        {
            placeholders = placeholders + "|";
        }
        // Replace all instances of the subsequence with placeholder
        locations = this.sequence.Replace(sub, placeholders);
        // Remove newlines so there aren't extra periods
        locations = locations.Replace(System.Environment.NewLine, "");
        // Use regular expressions to replace non-placeholders with periods
        locations = Regex.Replace(locations, "[^|]", ".");
        // Replace the placeholders with the original subsequence and return
        locations = locations.Replace(placeholders, sub);
        return locations;
    }

    // Write the FASTA description of the protein to a given text stream.
    public void WriteFasta(TextWriter output)
    {
        // Write this
        // protein's information, in FASTA form, to the TextWriter stream 
        // passed as a paramter.
        string splitsequence = null;
        // To keep us under the 80 character per line limit
        string newline = System.Environment.NewLine;
        // Turn the sequence into 80 character parts separated by a newline
        for (int i = 0; i < this.sequence.Length; i++)
        {
            // Every 80 characters, insert a newline
            if (i % 80 == 0 && (this.sequence[i].ToString() != newline))
            {
                splitsequence += System.Environment.NewLine;
            }
            // Add the current character to the splitsequence
            splitsequence += this.sequence[i];
        }
        // Create part of the header to keep us within the 80 character limit
        string header = ">" + this.id + " " + this.name;
        // Output the full FASTA entry
        output.WriteLine("{0}{1}{2}", header, newline, this.sequence);
        return;
    }
}

// Read a protein file into a collection and test the functionality of
// methods in the Protein class.
static class Program
{
    static string fastaFile = "protein.fasta";

    // The collection
    // to hold the proteins read from the file.
    static List<Protein> proteins = new List<Protein>();

    static void Main()
    {
        // Read proteins in FASTA format from the file.
        using (StreamReader sr = new StreamReader(fastaFile))
        {
            // Statements to collect
            // the header and sequence lines for one protein, form
            // the new Protein object, and add it to the collection.
            string line = sr.ReadLine();
            string sequence;
            string header;
            string[] splitHdr;
            
            // Until the end of the file
            while (line != null)
            {
                sequence = null;
                header = line;
                // Read the header line
                line = sr.ReadLine();
                // Verify it's actually a header line and not blank, invalid,
                // or not a header
                while (line != null && (line.StartsWith(">") == false))
                {
                    // Add the next lines that aren't empty or a header to
                    // the sequence.
                    sequence += line;
                    line = sr.ReadLine();
                }
                // Remove the >
                header = header.Replace(">", "");
                // Split the header into two parts - the first being the id
                // and the second being the name.
                splitHdr = header.Split(new char[] { ' ' }, 2);
                proteins.Add(new Protein(splitHdr[0], splitHdr[1], sequence));
            }
        }

        // Report count of proteins loaded.
        Console.WriteLine();
        Console.WriteLine("Loaded {0} proteins from the {1} file.",
            proteins.Count, fastaFile);

        // Report proteins containing a specified sequence.
        Console.WriteLine();
        Console.WriteLine("Proteins containing sequence RILED:");
        foreach (Protein p in proteins)
        {
            if (p.ContainsSubsequence("RILED"))
            {
                Console.WriteLine(p.Name);
            }
        }

        // Report proteins containing a repeated sequence.
        Console.WriteLine();
        Console.WriteLine(
            "Proteins containing sequence SNL more than 5 times:");
        foreach (Protein p in proteins)
        {
            if (p.CountSubsequence("SNL") > 5)
            {
                Console.WriteLine(p.Name);
            }
        }

        // Locate the specified sequence in proteins containing it.
        Console.WriteLine();
        Console.WriteLine("Proteins containing sequence DEVGG:");
        foreach (Protein p in proteins)
        {
            if (p.ContainsSubsequence("DEVGG"))
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.LocateSubsequence("DEVGG"));
            }
        }

        // Show FASTA output for proteins containing a specified sequence.
        Console.WriteLine();
        Console.WriteLine("Proteins containing sequence DEVGG:");
        foreach (Protein p in proteins)
        {
            if (p.ContainsSubsequence("DEVGG"))
            {
                p.WriteFasta(Console.Out);
            }
        }

    }
}