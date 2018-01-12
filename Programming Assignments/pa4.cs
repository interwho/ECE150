// -------------------------------------------------------------------
// Department of Electrical and Computer Engineering
// University of Waterloo
//
// Student Name:     Justin Paulin
// Userid:           j2paulin
//
// Assignment:       Programming Assignment 4
// Submission Date:  01/12/2014
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// None
// -------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

// ----------------------------------------------------------------------------
// A Drug object holds information about one fee-for-service outpatient drug 
// reimbursed by Medi-Cal (California's Medicaid program) to pharmacies.
class Drug : IComparable
{
    string name;            // brand name, strength, dosage form
    string id;              // national drug code number
    double size;            // package size
    string unit;            // unit of measurement
    double quantity;        // number of units dispensed
    double lowest;          // price Medi-Cal is willing to pay
    double ingredientCost;  // estimated ingredient cost
    int numTar;             // number of claims with a treatment auth. request
    double totalPaid;       // total amount paid
    double averagePaid;     // average paid per prescription
    int daysSupply;         // total days supply
    int claimLines;         // total number of claim lines
    
    // Properties providing read-only access to every field.
    public string Name { get { return name; } }               
    public string Id { get { return id; } }                 
    public double Size { get { return size; } }             
    public string Unit { get { return unit; } }             
    public double Quantity { get { return quantity; } }         
    public double Lowest { get { return lowest; } }             
    public double IngredientCost { get { return ingredientCost; } }    
    public int NumTar { get { return numTar; } }                
    public double TotalPaid { get { return totalPaid; } }          
    public double AveragePaid { get { return averagePaid; } }        
    public int DaysSupply { get { return daysSupply; } }            
    public int ClaimLines { get { return claimLines; } }            
    
    public Drug ( string name, string id, double size, string unit, 
        double quantity, double lowest, double ingredientCost, int numTar, 
        double totalPaid, double averagePaid, int daysSupply, int claimLines )
    {
        this.name = name;
        this.id = id;
        this.size = size;
        this.unit = unit;
        this.quantity = quantity;
        this.lowest = lowest;
        this.ingredientCost = ingredientCost;
        this.numTar = numTar;
        this.totalPaid = totalPaid;
        this.averagePaid = averagePaid;
        this.daysSupply = daysSupply;
        this.claimLines = claimLines;
    }

    // Simple string for debugging purposes, showing only selected fields.
    public override string ToString( )
    { 
        return string.Format( 
            "{0}: {1}, {2}", id, name, size ); 
    }

    public int CompareTo( object obj ) 
    {
        // Check if object is a drug
        if (obj is Drug)
        {
            // If names are equal, return 0
            if (this.name == obj.name)
            {
                return 0;
            }
            // Perform comparison if names aren't equal
            if (this.name.CompareTo(obj.name) > 0)
            {
                return 1;
            }
            if (this.name.CompareTo(obj.name) < 0)
            {
                return -1;
            }
        }
        else
        {
            // Object is not a drug
            throw new ArgumentException("Not drug, no comparison possible!");
        }
    }

}

// ----------------------------------------------------------------------------
// Linked list of Drugs.  A list object holds references to its head and tail
// Nodes and a count of the number of Nodes.
class DrugList
{
    // Nodes form the singly linked list.  Each node holds one Drug item.
    class Node : IComparable
    {
        Node next;
        Drug data;
        
        public Node( Drug data ) { next = null; this.data = data; }
        
        public Node Next{ get { return next; } set { next = value; } }
        public Drug Data{ get { return data; } }

        public int CompareTo( object obj )
        {
            // Check that object is a node
            if (obj is Node)
            {
                // Compare the data in each node to obj
                return this.Data.CompareTo(obj.Data);
            }
            else
            {
                // Object is not a node, no comparison possible
                throw new ArgumentException("Not node, no comparison possible!");
            }
        }

    }
    
    Node tail;
    Node head;
    int count;
    
    public int Count { get { return count; } }
    
    // Constructors:
    public DrugList( ) { tail = null; head = null; count = 0; }
    public DrugList( string drugFile ) : this( ) { AppendFromFile( drugFile );}
   
    // Methods which add elements:
    // Build this list from a specified drug file.
    public void AppendFromFile( string drugFile )
    {
        using( StreamReader sr = new StreamReader( drugFile ) )
        {
            while( ! sr.EndOfStream )
            {
                string line = sr.ReadLine( );
                
                // Extract drug information
                string name = line.Substring( 7, 30 ).Trim( );
                string id = line.Substring( 37, 13 ).Trim( );
                string temp = line.Substring( 50, 14 ).Trim( );
                double size 
                    = double.Parse( temp.Substring( 0 , temp.Length - 2 ) );
                string unit = temp.Substring( temp.Length - 2, 2 );
                double quantity = double.Parse( line.Substring( 64, 16 ) );
                double lowest = double.Parse( line.Substring( 80, 10 ) );
                double ingredientCost 
                    = double.Parse( line.Substring( 90, 12 ) );
                int numTar = int.Parse( line.Substring( 102, 8 ) );
                double totalPaid = double.Parse( line.Substring( 110, 14 ) );
                double averagePaid = double.Parse( line.Substring( 124, 10 ) );
                int daysSupply 
                    = ( int ) double.Parse( line.Substring( 134, 14 ) );
                int claimLines = int.Parse( line.Substring( 148 ) );
                
                // Put drug onto this list of drugs.
                Append( new Drug( name, id, size, unit, quantity, lowest, 
                    ingredientCost, numTar, totalPaid, averagePaid, 
                    daysSupply, claimLines ) );
            }
        }
    }
    
    // Add a new Drug item to the end of this linked list.
    public void Append( Drug data )
    {
        // Make sure data is not null
        if (data == null)
        {
            return;
        }
        // Create a new list entry
        Node tmp = new Node(data);
        tmp.Next = null;
        // If this is the first element, set it as such
        if (this.head == null)
        {
            this.head = tmp;
        }
        else
        {
            // Set the next element in the tail to the current element
            this.tail.Next = tmp;
        }
        // Set the tail to the last element
        this.tail = tmp;
    }
    
    // Add a new Drug in order based on a user-supplied comparison method.
    // The new Drug goes just before the first one which tests greater than it.
    public void InsertInOrder( Drug data )
    {
        // Make sure data is not null
        if (data != null)
        {
            // Append the data to the list
            this.Append(data);
            // Sort the list to put that data in order
            this.SelectSort();
        }
    }
    
    // Methods which remove elements:
    // Remove the first Drug.
    public Drug RemoveFirst( )
    {
        // Make sure the list isn't empty
        if (this.head == null)
        {
            return null;
        }
        else
        {
            // Return and remove the first drug in the list from head
            Drug returner = this.head.Data;
            this.head = this.head.Next;
            return returner;
        }
    }
    
    // Remove the minimal Drug 
    public Drug RemoveMin(  )
    {
        // Make sure list isn't empty
        if (this.head == null)
        {
            return null;
        }
        else
        {
            // For the length of the list, compare each item in order
            for (int i = 0; this.count; i++)
            {
                // If the head is greater than the next element, remove element
                // and return it
                if (this.head.CompareTo(this.Next) == 1)
                {
                    Drug minimum = this.Next.Data;
                    this.Next = null;
                    return minimum;
                }
                // If no minimum found, return the head
                Drug minimumend = this.head;
                this.head = null;
                return minimumend;
            }
        }
    }
    
    // Methods which sort the list:
    // Sort this list by selection sort.
    public void SelectSort( )
    {
        // For each element in the list, remove the first minimum and append
        // it to the end. The result will work as such:
        // 7,53,2,19 --> 7,53,19,2 --> 2,7,19,53
        Drug minimum = null;
        for (int i = 0; this.count; i++)
        {
            minimum = this.RemoveMin();
            this.Append(minimum);
        }
    }
    
    // Sort this list by insertion sort
    public void InsertSort( )
    {
        Drug current = null;
        // For each element in the list, remove the first element
        // and insert it in order. This way each element is sorted once.
        for (int i = 0; this.Count; i++)
        {
            current = this.RemoveFirst();
            this.InsertInOrder(current);
        }
    }
    
    // Methods which extract the Drugs:
    // Return, as an array, references to all the Drug objects on the list.
    public Drug[ ] ToArray( )
    {
        Drug[ ] result = new Drug[ count ];
        int nextIndex = 0;
        Node current = head;
        while( current != null )
        {
            result[ nextIndex ] = current.Data;
            nextIndex ++;
            current = current.Next;
        }
        return result;
    }
    
    // Return a collection of references to the Drug items on this list which 
    // can be used in a foreach loop.  Understanding enumerations and the 
    // 'yield return' statement is beyond the scope of the course.
    public IEnumerable< Drug > Enumeration
    {
        get
        {
            Node current = head;
            while( current != null )
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

// ----------------------------------------------------------------------------
// Test the linked list of Drugs.
static class Program
{
    static void Main( )
    {
        DrugList drugs = new DrugList( "RXQT1402.txt" );
        drugs.InsertSort( );
        foreach( Drug d in drugs.ToArray( ) ) Console.WriteLine( d );
    }
}
